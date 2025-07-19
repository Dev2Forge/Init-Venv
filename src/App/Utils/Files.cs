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
 * Last Modified: Friday, 18th July 2025 11:30:46 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.Utils
{
    public static class Files
    {
        public static bool Exists(string arg)
        {
            string fullPath = Paths.ToUniversalPaths(arg);
            return Path.Exists(fullPath);
        }
    }
}