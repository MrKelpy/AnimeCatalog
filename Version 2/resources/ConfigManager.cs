using System.Collections.Generic;
using System.IO;
using System.Text.Json;
// ReSharper disable PossibleNullReferenceException

namespace PFM5.resources
{
    public class ConfigManager
    {
        private const string ConfigPath = "./config";

        public string GetPathValue(string pathKey)
        /* Returns the path value from the Paths.json file.
         * :return string: The path value from the config.
         */
        {
            string jsonString = File.ReadAllText(ConfigPath + "/Paths.json");
            var result = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            return result?[pathKey];
        }
    }
}