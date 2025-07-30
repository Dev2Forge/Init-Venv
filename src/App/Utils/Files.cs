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
 * Last Modified: Monday, 28th July 2025 2:56:10 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.utils
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
    }
}