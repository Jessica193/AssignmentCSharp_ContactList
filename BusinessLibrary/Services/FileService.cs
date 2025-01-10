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

        /// <summary>
        /// Konstruktor som inte hårdkodar _directoryPath till "Data" eftersom androidsimulatorn inte kunde skapa den vägen och 
        /// då inte heller spara kontakten till filen. När SaveListToFile kördes så gick programmet in i catchen.
        /// Modifiering av konstruktorn gjord av chatGPT. Gamla konstruktorn ligger utkommenterad längst ner i filen.
        /// </summary>
        /// <param name="directoryName">Katalognamn</param>
        /// <param name="fileName">Filnamn</param>
        public FileService(string directoryName = "Data", string fileName = "list.json")
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _directoryPath = Path.Combine(basePath, directoryName);
            _filePath = Path.Combine(_directoryPath, fileName);
            _options = new JsonSerializerOptions() { WriteIndented = true };
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


//Gamla konstruktorn

//public FileService(string directoryPath = "Data", string fileName = "list.json")
//{
//    _directoryPath = directoryPath;
//    _filePath = Path.Combine(directoryPath, fileName);
//    _options = new JsonSerializerOptions() { WriteIndented = true};
//}