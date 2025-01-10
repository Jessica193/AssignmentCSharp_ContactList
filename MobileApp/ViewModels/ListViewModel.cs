using BusinessLibrary.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MobileApp.ViewModels;

public partial class ListViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    [ObservableProperty]
    private ObservableCollection<BusinessLibrary.Models.Contact> _contactList = [];

    public ListViewModel(IContactService contactService)
    {
        _contactService = contactService;
        UpdateContactList();

        _contactService.ContactsUpdated += (sender, e) =>
        {
            UpdateContactList();
        };
    }

    public void UpdateContactList()
    {
        ContactList = new ObservableCollection<BusinessLibrary.Models.Contact>(_contactService.GetContacts());
    }


    [RelayCommand]
    public async Task NavigateToAdd()
    {
        try
        {
            await Shell.Current.GoToAsync("AddPage");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    public async Task NavigateToEdit(BusinessLibrary.Models.Contact contact)
    {

        try
        {
            var parameters = new ShellNavigationQueryParameters
            {
                {"contact", contact }
            };
            await Shell.Current.GoToAsync("EditPage", parameters);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    public void Remove(BusinessLibrary.Models.Contact contact)
    {
        try
        {
            _contactService.RemoveContactFromList(contact);
            UpdateContactList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }


    }


}
