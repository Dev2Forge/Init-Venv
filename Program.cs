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
 * Last Modified: Sunday, 27th July 2025 8:17:43 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using App;

namespace InitVenv
{
    class App
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Init-Venv (C) 2025 - Dev2Forge\nBy Tutos Rive\nAll Rights Reserved.\n");
            await Init.Run();
        }
    }
}