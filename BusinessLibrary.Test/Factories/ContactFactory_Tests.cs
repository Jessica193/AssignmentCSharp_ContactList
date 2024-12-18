using BusinessLibrary.Factories;
using BusinessLibrary.Models;

namespace BusinessLibrary.Tests.Factories;

public class ContactFactory_Tests
{
    [Fact]
    public void CreateContactRegistrationForm_ShouldReturnContactRegistrationForm()
    {
        //arrange

        //act
        ContactRegistrationForm result = ContactFactory.CreateContactRegistrationForm();

        //assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegistrationForm>(result); 
    }

    [Fact]
    public void CreateContact_ShouldReturnContact_WhenProductRegistrationFormIsSupplied()
    {
        //arrange
        ContactRegistrationForm form = new ContactRegistrationForm() { FirstName = "Jessica"};   

        //act
        Contact result = ContactFactory.CreateContact(form);

        //assert
        Assert.NotNull(result);
        Assert.IsType<Contact>(result);
        Assert.Equal(form.FirstName, result.FirstName);
    }
}
