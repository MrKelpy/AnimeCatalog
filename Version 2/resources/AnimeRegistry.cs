using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PFM5.resources.content;
// ReSharper disable PossibleNullReferenceException

namespace PFM5.resources
{
    public static class AnimeRegistry
    {
        public static void LoadIntoAnimeRegistry(Anime anime)
        /* Loads the anime registry from the Anime class into the AnimeRegistry.json file.
         * 
         * :param Anime anime: The anime to load into the registry.
         * :return void:
         */
        {
            string animeRegistryPath = new ConfigManager().GetPathValue("anime_registry");
            Directory.CreateDirectory(animeRegistryPath);
            string jsonString = File.ReadAllText(animeRegistryPath);
            
            var animeRegistry = JsonSerializer.Deserialize<Dictionary<string, Anime>>(jsonString);
            animeRegistry[anime.GetName()] = anime;
        }

        public static bool CheckInRegistry(Anime anime)
        /* Checks if a given anime is in the Registry and if it isn't expired already.
         * :return bool: True if the anime is in the registry and not expired, false otherwise.
         */
        {
            string animeRegistryPath = new ConfigManager().GetPathValue("anime_registry");
            string jsonString = File.ReadAllText(animeRegistryPath);
            var animeRegistry = JsonSerializer.Deserialize<Dictionary<string, Anime>>(jsonString);
        
            // Check if the anime is in the registry and if it isn't expired already.
            return animeRegistry.ContainsKey(anime.GetName()) &&
                   animeRegistry[anime.GetName()].GetNextEpisodeTimestamp() < DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public static List<Anime> ReadRegistry()
        /* Returns a list of Animes present in the AnimeRegistry.json file.
         * :return List<Anime>: A list of Animes present in the AnimeRegistry.json file.
         */
        {
            string animeRegistryPath = new ConfigManager().GetPathValue("anime_registry");
            string jsonString = File.ReadAllText(animeRegistryPath);
            var animeRegistry = JsonSerializer.Deserialize<List<Anime>>(jsonString);

            return animeRegistry;
        }
    }
}