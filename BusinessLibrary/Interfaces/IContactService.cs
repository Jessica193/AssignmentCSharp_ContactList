using BusinessLibrary.Models;

namespace BusinessLibrary.Interfaces
{
    public interface IContactService
    {
        bool AddContactToList(Contact contact);
        IEnumerable<Contact> GetContacts();
        bool RemoveContactFromList(Contact contact);
        bool UpdateContactList(Contact contact);
        event EventHandler? ContactsUpdated;
    }
}
