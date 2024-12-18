using BusinessLibrary.Helpers;
using BusinessLibrary.Interfaces;
using BusinessLibrary.Models;
using System.Diagnostics;

namespace BusinessLibrary.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<Contact> _contacts = [];

    public bool AddContactToList(Contact contact)
    {
        try
        {
            contact.Id = UniqueIdGenerator.GenerateUniqueId();
            _contacts.Add(contact);
            _fileService.SaveListToFile(_contacts);
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
}
