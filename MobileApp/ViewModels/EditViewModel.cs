using BusinessLibrary.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MobileApp.ViewModels;

public partial class EditViewModel : ObservableObject
{
}
public partial class EditViewModel : ObservableObject, IQueryAttributable
{
    private readonly IContactService _contactService;

    public EditViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }


    [ObservableProperty]
    private BusinessLibrary.Models.Contact _contact = new();


    [RelayCommand]
    public async Task Update()
    {
        if (Contact != null)
        {
            var result = _contactService.UpdateContactList(Contact);
            Contact = new();

            if (result)
            {
                await Shell.Current.GoToAsync("//ListPage");
            }
        }

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Contact = (query["contact"] as BusinessLibrary.Models.Contact)!;
    }
}
