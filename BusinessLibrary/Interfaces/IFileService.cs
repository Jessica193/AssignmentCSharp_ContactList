using BusinessLibrary.Models;

namespace BusinessLibrary.Interfaces;

public interface IFileService
{
    bool SaveListToFile(List<Contact> list);
    List<Contact> LoadListFromFile();
}
