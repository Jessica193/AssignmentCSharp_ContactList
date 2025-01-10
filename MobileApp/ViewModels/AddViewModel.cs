using BusinessLibrary.Factories;
using BusinessLibrary.Interfaces;
using BusinessLibrary.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MobileApp.ViewModels;

public partial class AddViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    public AddViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }


    [ObservableProperty]
    private ContactRegistrationForm _form = new();


    [RelayCommand]
    public async Task Add()
    {
        if (Form != null && !string.IsNullOrEmpty(Form.FirstName))
        {
            var contact = ContactFactory.CreateContact(Form);

            var result = _contactService.AddContactToList(contact);
            Form = new();

            if (result)
            {
                await Shell.Current.GoToAsync("//ListPage");
            }
        }

    }
}
