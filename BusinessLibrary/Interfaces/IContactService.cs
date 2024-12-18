using BusinessLibrary.Models;

namespace BusinessLibrary.Interfaces
{
    public interface IContactService
    {
        bool AddContactToList(Contact contact);
        IEnumerable<Contact> GetContacts();
    }
}
