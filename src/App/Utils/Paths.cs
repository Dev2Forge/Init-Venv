/*
 * Utils - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Paths.cs
 * Created: Friday, 18th July 2025 7:00:41 pm
 * -----
 * Last Modified: Sunday, 20th July 2025 1:36:00 am
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.Utils
{
    public static class Paths
    {
        /// <summary>
        /// Format any <strong>path</strong> so it can be used on any OS (On Windows, the paths using backslash)
        /// </summary>
        /// <param name="path">The "<strong>path</strong>" to format</param>
        /// <returns>A string with the formated <strong>path</strong></returns>
        public static string ToUniversalPaths(string path)
        {
            return path.Replace("\\", "/");
        }

        public static string AbsoluteUniversalPath(string path)
        {
            try
            {
                return ToUniversalPaths(Path.GetFullPath(path));
            }
            catch (Exception) { throw; }

            throw new Exception("The absolute path could not be determined");
        }
    }
}