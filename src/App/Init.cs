/*
 * App - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Main.cs
 * Created: Sunday, 27th July 2025 2:17:28 pm
 * -----
 * Last Modified: Thursday, 20th November 2025 3:00:42 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.utils;
using InitVenv.src.App.os;
using InitVenv.src.App.os.windows;
using System.Threading.Tasks;

namespace App
{

    public class Init
    {
        public static async Task Run(string path)
        {
            string? os = OS.GetOS();
            
            switch (os)
            {
                case "Windows":
                    await WindowsInit.Run(path);
                    break;
                case "MacOS":
                case "Linux":
                    Console.WriteLine("The system is not allowed right now...");
                    break;
                default:
                    throw new Exception("The Operating System isn't allowed!");
            }
        }
    }
}