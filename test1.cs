/*
 * Init-Venv - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \test1.cs
 * Created: Friday, 18th July 2025 7:00:41 pm
 * -----
 * Last Modified: Friday, 18th July 2025 11:29:12 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */


using InitVenv.src.App.Utils;
namespace InitVenv
{
    class App1
    {
        public static void FileTest(string pathArg)
        {
            string __fullPath = Paths.ToUniversalPaths(Path.GetFullPath(pathArg)); Console.WriteLine(string.Format("{0}", __fullPath));
        }
    }
}