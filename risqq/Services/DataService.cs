using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace risqq
{
    internal class DataService
    {
        public async Task SaveUserSettingsAsync(UserSettings UserSettings)
        {
            string fileName = "UserSettings.json";
            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, UserSettings);
            Console.WriteLine($"Data saved to {createStream.Name}");
        }

        public async Task<UserSettings> LoadUserSettingsAsync() {
            try
            {
                string fileName = "UserSettings.json";
                using FileStream openStream = File.OpenRead(fileName);
                UserSettings? userSettings =
                    await JsonSerializer.DeserializeAsync<UserSettings>(openStream);
                return userSettings;
            }
            catch (FileNotFoundException) 
            {
                Console.WriteLine("Unable to load settings. File not found.");
                throw;
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Error loading settings: {e.Message}");
                throw;
            }
        }
    }
}
