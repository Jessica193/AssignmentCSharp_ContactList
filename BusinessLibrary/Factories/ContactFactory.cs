using BusinessLibrary.Models;

namespace BusinessLibrary.Factories
{
    public static class ContactFactory
    {
        public static ContactRegistrationForm CreateContactRegistrationForm()
        {
            return new ContactRegistrationForm();
        }

        public static Contact CreateContact(ContactRegistrationForm form)
        {
            return new Contact
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                Address = form.Address,
                PostalCode = form.PostalCode,
                City = form.City,
            };
        }
    }
}
