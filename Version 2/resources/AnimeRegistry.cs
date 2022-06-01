using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using PFM5.resources.content;
// ReSharper disable PossibleNullReferenceException

namespace PFM5.resources
{
    public static class AnimeRegistry
    {
        public static void LoadIntoAnimeRegistry(Anime anime)
        /* Loads the anime into the Anime Registry file. This is done through
         * a series of serialization/deserialization steps to write the data into the
         * AnimeRegistry.json file.
         * 
         * :param Anime anime: The anime to load into the registry.
         * :return void:
         */
        {
            // Load the anime registry from the AnimeRegistry.json file.
            string animeRegistryPath = ConfigManager.GetPathValue("anime_registry");
            
            // Deserialize the json string into a dictionary and update it
            var animeRegistry = AnimeRegistry.ReadRegistry().ToDictionary(x=> x.Key,
                y=> y.Value.ToSerializationModel());
            animeRegistry[anime.GetAnimeUrl()] = anime.ToSerializationModel();
            
            // Serialize the dictionary into a json string and write it to the file.
            string jsonSerializedString = JsonSerializer.Serialize(animeRegistry);
            File.WriteAllText(animeRegistryPath, jsonSerializedString);
        }

        public static bool CheckInRegistry(string animeUrl)
        /* Checks if a given anime is in the Registry and if it isn't expired already.
         * :return bool: True if the anime is in the registry and not expired, false otherwise.
         */
        {
            var animeRegistry = AnimeRegistry.ReadRegistry();
        
            // Check if the anime is in the registry and if it isn't expired already.
            return animeRegistry.ContainsKey(animeUrl) &&
                   animeRegistry[animeUrl].GetNextEpisodeTimestamp() < DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public static Dictionary<string, Anime> ReadRegistry()
        /* Returns a list of Animes present in the AnimeRegistry.json file.
         * :return List<Anime>: A list of Animes present in the AnimeRegistry.json file.
         */
        {
            string animeRegistryPath = ConfigManager.GetPathValue("anime_registry");
            string jsonString = File.ReadAllText(animeRegistryPath);
            
            // Deserialize the json string into a dictionary and return it. If the registry is empty, return an empty dictionary.
            try {
                var jsonDeserialized = JsonSerializer.Deserialize<Dictionary<string, AnimeSerializationModel>>(jsonString);
                return jsonDeserialized?.ToDictionary(x=> x.Key,
                    y=> y.Value.FromSerializationModel());

            } catch (ArgumentNullException) { return new Dictionary<string, Anime>(); }
        }
    }
}