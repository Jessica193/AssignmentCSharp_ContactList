using BusinessLibrary.Helpers;
using BusinessLibrary.Interfaces;
using BusinessLibrary.Models;
using System.Diagnostics;

namespace BusinessLibrary.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<Contact> _contacts = [];
    public event EventHandler? ContactsUpdated;  //NYTT 

    public bool AddContactToList(Contact contact)
    {
        if (contact == null)
        {
            return false;
        }

        try
        {
            contact.Id = UniqueIdGenerator.GenerateUniqueId();
            _contacts.Add(contact);
            _fileService.SaveListToFile(_contacts);
            ContactsUpdated?.Invoke(this, EventArgs.Empty);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }


    }

    public IEnumerable<Contact> GetContacts()
    {
        try
        {
            _contacts = _fileService.LoadListFromFile();
            return _contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }


    //NY METODER 

    public bool RemoveContactFromList(Contact contact)
    {
        if (contact == null)
        {
            return false;
        }

        try
        {
            var selectedContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (selectedContact != null)
            {
                _contacts.Remove(selectedContact);
                _fileService.SaveListToFile(_contacts);
                ContactsUpdated?.Invoke(this, EventArgs.Empty);
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

    public bool UpdateContactList(Contact contact)
    {
        if (contact == null)
        {
            return false;
        }

        try
        {
            var selectedContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (selectedContact != null)
            {
                selectedContact = contact;
                _fileService.SaveListToFile(_contacts);
                ContactsUpdated?.Invoke(this, EventArgs.Empty);
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
}
