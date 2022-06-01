using System.Collections.Generic;
using System.IO;
using System.Text.Json;
// ReSharper disable PossibleNullReferenceException

namespace PFM5.resources
{
    public static class ConfigManager
    /* ConfigManager is a class that manages the different configuration files for the program
     * to function correctly.
     */
    {
        private const string ConfigPath = "./config";

        public static string GetPathValue(string pathKey)
        /* Returns the path value from the Paths.json file.
         *
         * :param pathKey: The key of the path to return.
         * :return string: The path value from the config.
         */
        {
            string jsonString = File.ReadAllText(ConfigPath + "/Paths.json");
            var result = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            return result?[pathKey];
        }
    }
}