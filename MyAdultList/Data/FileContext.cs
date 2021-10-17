using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;
using Restricting.Models;

namespace MyAdultList.Data
{
    public class FileContext
    {
        
        public IList<Adult> Adults { get; private set; }
        public IList<User> Users { get; private set; }

        
        private readonly string adultsFile = "Data/Files/adults.json";
        private readonly string usersFile = "Data/Files/users.json";

        public FileContext()
        {
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
            Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
            
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(usersFile, false))
            {
                outputFile.Write(jsonUsers);
            }
        }
    }
}