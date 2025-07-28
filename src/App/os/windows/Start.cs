/*
 * windows - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Start.cs
 * Created: Sunday, 27th July 2025 8:31:25 pm
 * -----
 * Last Modified: Sunday, 27th July 2025 8:46:31 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;

namespace InitVenv.src.App.os.windows
{
    public class WindowsInit
    {
        public static async Task Run()
        {
            CommandResult result = await WindowsCommands.ExecuteCommandAsync("cmd.exe", "PipPaths");
            if (result.ExceptionData != null)
            {
                foreach (var item in result.ExceptionData)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}