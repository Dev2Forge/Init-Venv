/*
 * Utils - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Files.cs
 * Created: Friday, 18th July 2025 7:00:41 pm
 * -----
 * Last Modified: Saturday, 19th July 2025 12:43:47 am
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using System.Text.Json;

namespace InitVenv.src.App.Utils
{
    public static class Files
    {
        public static bool Exists(string arg)
        {
            string fullPath = Paths.ToUniversalPaths(arg);
            return Path.Exists(fullPath);
        }

        public static T ReadJSON<T>(string pathFile)
        {
            string content;
            T? commands;
            Console.WriteLine(string.Format("Tipo de \"T\": {0}", typeof(T)));

            // Check file exist before read
            if (Exists(pathFile))
            {
                using StreamReader reader = new(pathFile);
                try
                {
                    content = reader.ReadToEnd();
                    commands = JsonSerializer.Deserialize<T>(content);

                    // The file is OK and was deserialized
                    if (commands != null) return commands;

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new FileNotFoundException(string.Format("File \"{0}\" not found", pathFile));
            }

            throw new JsonException("Was not possible deserialize the file");

        }
    }
}