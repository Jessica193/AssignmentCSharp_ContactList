using BusinessLibrary.Interfaces;
using BusinessLibrary.Models;
using BusinessLibrary.Services;
using Moq;

namespace BusinessLibrary.Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactService = new ContactService(_fileServiceMock.Object);
    }

    [Fact]
    public void AddContactToList_ShouldReturnTrue_WhenCotactIsAddedToLIst()
    {
        //arrange
        Contact contact = new Contact() { FirstName = "Jessica" };

        _fileServiceMock
            .Setup(fs => fs.SaveListToFile(It.IsAny<List<Contact>>()))
            .Returns(true);

        //act
        bool result = _contactService.AddContactToList(contact);

        //assert
        _fileServiceMock.Verify(fs => fs.SaveListToFile(It.IsAny<List<Contact>>()), Times.Once());
        Assert.True(result);

    }

    [Fact]
    public void GetContacts_ShouldReturnListOfContacts()
    {
        //arrange
        List<Contact> contacts = new() { new Contact { FirstName = "Jessica"}};

        _fileServiceMock.Setup(fs => fs.LoadListFromFile()).Returns(contacts);

        //act
        IEnumerable<Contact> result = _contactService.GetContacts();

        //assert
        Assert.Single(result);
        Assert.Equal(contacts.First().FirstName, result.First().FirstName);
        Assert.Equal(contacts, result);
    }
}
