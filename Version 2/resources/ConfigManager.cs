using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PFM5.resources
{
    public class ConfigManager
    {
        public string GetPathValue(string pathKey)
        /* Returns the path value from the Paths.json file.
         * :return string: The path value from the config.
         */
        {
            string cwd = AppDomain.CurrentDomain.BaseDirectory;
            string configPaths = Path.Combine(cwd, "/config/Paths.json");
            string jsonString = File.ReadAllText(Path.Combine(cwd, configPaths));
            var result = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            return result?[pathKey];
        }
    }
}