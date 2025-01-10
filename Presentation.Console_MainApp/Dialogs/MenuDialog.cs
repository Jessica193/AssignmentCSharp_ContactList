using BusinessLibrary.Factories;
using BusinessLibrary.Interfaces;
using BusinessLibrary.Models;
using BusinessLibrary.Services;
using Presentation.Console_MainApp.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace Presentation.Console_MainApp.Dialogs;

public class MenuDialog(IContactService contactService) : IMenuDialog
{
    private readonly IContactService _contactService = contactService;

    public void RunProgram()
    {
        while (true)
        {
            string result = MainMenu();

            if (!string.IsNullOrEmpty(result))
            {
                OptionSwitch(result);
            }
            else
            {
                DialogOutput("Please enter a valid option.");
            }
        }
    }
    public string MainMenu()
    {
        Console.Clear();
        Console.WriteLine("********** Main Menu **********");
        Console.WriteLine("");
        Console.WriteLine($"{"1. ",-5} Create a contact");
        Console.WriteLine($"{"2. ",-5} View all contacts");
        Console.WriteLine("------------------------------------------");
        Console.Write("Choose an option: ");
        string result = Console.ReadLine()!.Trim();

        return result;
    }

    public void OptionSwitch(string result)
    {
        switch (result)
        {
            case "1":
                CreateContact();
                break;

            case "2":
                ViewAllContacts();
                break;

            default:
                DialogOutput("Please enter a valid option.");
                break;
        }
    }

    public void DialogOutput(string message)
    {
        Console.Clear();
        Console.WriteLine(message + " Press any key to continue...");
        Console.ReadKey();

    }
    public bool CreateContact()
    {
        try
        {
            ContactRegistrationForm form = ContactFactory.CreateContactRegistrationForm();

            form.FirstName = PromtAndValidate("Please enter your first name", nameof(form.FirstName));
            form.LastName = PromtAndValidate("Please enter your last name", nameof(form.LastName));
            form.Email = PromtAndValidate("Please enter your email address", nameof(form.Email));
            form.PhoneNumber = PromtAndValidate("Please enter your phone number", nameof(form.PhoneNumber));
            form.Address = PromtAndValidate("Please enter your street address", nameof(form.Address));
            form.PostalCode = PromtAndValidate("Please enter your postal code", nameof(form.PostalCode));
            form.City = PromtAndValidate("Please enter your city", nameof(form.City));

            Contact contact = ContactFactory.CreateContact(form);
            
            if (_contactService.AddContactToList(contact))
            {
                DialogOutput("The contact was successfully created.");
                return true;
            }
    
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public bool ViewAllContacts()
    {
        try
        {
            IEnumerable<Contact> _contacts = _contactService.GetContacts();

            Console.Clear();
            foreach (var contact in _contacts)
            {
                Console.WriteLine($"Id: {contact.Id}");
                Console.WriteLine($"First name: {contact.FirstName}");
                Console.WriteLine($"Last name: {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Phone number: {contact.PhoneNumber}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"Postal code: {contact.PostalCode}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return false;
        }
    }
    public string PromtAndValidate(string promt, string propertyName)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(promt);
            string input = Console.ReadLine()!.Trim() ?? string.Empty;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(new ContactRegistrationForm()) { MemberName = propertyName };

            if (Validator.TryValidateProperty(input, context, results))
            {
                return input;
            }
            else
            {
                Console.WriteLine($"{results[0].ErrorMessage}. Press any key to try again...");
                Console.ReadKey();
            }

        }
    }
}
