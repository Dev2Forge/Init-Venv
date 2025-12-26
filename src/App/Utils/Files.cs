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
 * Last Modified: Thursday, 25th December 2025 8:53:23 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.utils
{
    public static class Files
    {
        private static readonly string OSRELEASEFILE = "/etc/os-release";

        public static bool Exists(string arg)
        {
            string fullPath = Paths.AbsoluteUniversalPath(arg);
            return Path.Exists(fullPath);
        }

        public static string[]? ReadPlainFileAsArray(string filePath)
        {
            if (!Exists(filePath))
            {
                throw new FileNotFoundException("This Linux distribution does not have the '/etc/os-release' file; please ensure that this file exists.");
            }

            string[]? readed = File.ReadAllLines(filePath);
            return readed;
        }

        public static string? ReadPlainFile(string filePath)
        {
            if (!Exists(filePath))
            {
                throw new FileNotFoundException("This Linux distribution does not have the '/etc/os-release' file; please ensure that this file exists.");
            }

            string? readed = File.ReadAllText(filePath);
            return readed;
        }

        public static Dictionary<string, string> ParseOSReleaseToDictionary()
        {
            Dictionary<string, string> data = [];
            string[]? fileReaded = ReadPlainFileAsArray(OSRELEASEFILE);

            if (fileReaded?.Length > 0)
            {
                foreach (string line in fileReaded)
                {
                    string[] lineParts = line.Split("=");
                    data.Add($"{lineParts[0]}", $"{lineParts[1]}");
                }
                
                if (data.Count == 0)
                {
                    throw new FormatException("The /etc/os-release file is not in the correct format");
                }
                
                return data;
            }

            throw new Exception("Not was possible parse the /etc/os-release/ file");
        }
    }
}