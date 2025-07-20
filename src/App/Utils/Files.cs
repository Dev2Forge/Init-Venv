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
 * Last Modified: Saturday, 19th July 2025 11:26:57 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using System.Text.Json;

namespace InitVenv.src.App.Utils
{
    public static class Files
    {
        /// <summary>
        /// Check if any file exists in the OS
        /// </summary>
        /// <param name="arg">The file to check</param>
        /// <returns>A bool that indicates if exists or not</returns>
        public static bool Exists(string arg)
        {
            string fullPath = Paths.ToUniversalPaths(arg);
            return Path.Exists(fullPath);
        }

        /// <summary>
        /// Try "read" JSON files and return its content (Needs a class to understand the JSON format)
        /// </summary>
        /// <typeparam name="T">The "interface" to understand the file format (its keys, values, types...)</typeparam>
        /// <param name="pathFile">The path to the file (Absolute path)</param>
        /// <returns>If not have errors, return the file content (The interface <strong>T</strong>)</returns>
        /// <exception cref="FileNotFoundException">This function check if the file exists</exception>
        /// <exception cref="JsonException">When the file contains an invalid format</exception>
        public static T ReadJSON<T>(string pathFile)
        {
            string content;
            T? commands;

            // Check file exist before read
            if (Exists(pathFile))
            {
                try
                {
                    // Try read and "Deserialize" the content
                    using StreamReader reader = new(pathFile);
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

            throw new JsonException(string.Format("Was not possible deserialize the file \"{0}\"", pathFile));

        }
    }
}