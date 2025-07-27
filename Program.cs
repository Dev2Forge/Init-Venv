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
 * Last Modified: Sunday, 27th July 2025 1:57:23 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;

namespace InitVenv
{
    class App
    {
        public static void Main(string[] args)
        {
            WindowsCommands win1 = IOsCommands.LoadConfigs<WindowsCommands>();
            string str = win1.ToString();

            Console.WriteLine(str);
        }
    }
}