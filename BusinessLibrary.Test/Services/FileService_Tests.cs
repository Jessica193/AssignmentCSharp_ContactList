using BusinessLibrary.Interfaces;
using BusinessLibrary.Models;
using Moq;

namespace BusinessLibrary.Tests.Services;

public class FileService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IFileService _fileService;

    public FileService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _fileService = _fileServiceMock.Object;
    }

    [Fact]
    public void SaveListToFile_ShouldReturnTrue_WhenListIsSavedToFile()
    {
        //arrange
        List<Contact> contacts = new List<Contact>() { new Contact { FirstName = "Jessica"} };

        _fileServiceMock.Setup(fs => fs.SaveListToFile(contacts)).Returns(true);

        //act
        bool result = _fileService.SaveListToFile(contacts);

        //assert
        Assert.True(result);
        _fileServiceMock.Verify(fs => fs.SaveListToFile(contacts), Times.Once);
    }

    [Fact]
    public void LoadListFromFile_ShouldReturnListOfContacts()
    {
        //arrange
        List<Contact> contacts = new List<Contact>() { new Contact { FirstName = "Jessica" } };
        _fileServiceMock.Setup(fs => fs.LoadListFromFile()).Returns(contacts);

        //act
        List<Contact> result = _fileService.LoadListFromFile();

        //assert
        Assert.IsType<List<Contact>>(result);
        Assert.Equal(contacts, result);
        Assert.Equal("Jessica", result.First().FirstName);
    }
}
