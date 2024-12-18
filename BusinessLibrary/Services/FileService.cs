using BusinessLibrary.Interfaces;
using BusinessLibrary.Models;
using System.Diagnostics;
using System.Text.Json;

namespace BusinessLibrary.Services
{
    public class FileService : IFileService
    {
        private readonly string _directoryPath;
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options;


        public FileService(string directoryPath = "Data", string fileName = "list.json")
        {
            _directoryPath = directoryPath;
            _filePath = Path.Combine(directoryPath, fileName);
            _options = new JsonSerializerOptions() { WriteIndented = true};
        }

        public bool SaveListToFile(List<Contact> list)
        {
            try
            {
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }

                var json = JsonSerializer.Serialize(list, _options);
                File.WriteAllText(_filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public List<Contact> LoadListFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    List<Contact> list = JsonSerializer.Deserialize<List<Contact>>(json, _options)!;
                    return list ?? [];
                }
                return [];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return [];
            }
        }

      
    }
}
