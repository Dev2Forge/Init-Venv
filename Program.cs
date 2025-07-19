/*
 * Init-Venv - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Program.cs
 * Created: Friday, 18th July 2025 7:00:41 pm
 * -----
 * Last Modified: Saturday, 19th July 2025 12:42:46 am
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;
using InitVenv.src.App.Utils;

namespace InitVenv
{
    class App
    {
        public static void Main(string[] args)
        {
            string? os = OS.GetOS();
            Console.WriteLine(os);

            WindowsCommands readed = Files.ReadJSON<WindowsCommands>("./src/App/configs/commands/Windows.jsonc");
            Console.WriteLine(readed.ActivateVenv);
        }
    }
}