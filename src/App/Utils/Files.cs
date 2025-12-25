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
 * Last Modified: Thursday, 20th November 2025 3:00:14 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.utils
{
    public static class Files
    {
        public static bool Exists(string arg)
        {
            string fullPath = Paths.AbsoluteUniversalPath(arg);
            return Path.Exists(fullPath);
        }
    }
}