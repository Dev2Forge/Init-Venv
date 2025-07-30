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
 * Last Modified: Tuesday, 29th July 2025 7:40:57 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.os.windows.models;

namespace InitVenv.src.App.os.windows
{
    public class WindowsInit
    {
        public static async Task Run()
        {
            // Objects instances
            WindowsRunner runner = new();
            Validators validators = new(runner);
            Commands commands = new();

            // Validations
            bool pythonIsOk = await validators.CheckPythonPaths();
            bool pipIsOk = await validators.CheckPipPaths();
            bool requirementsIsOk = validators.CheckRequirementsFile();

            // Commands Executions
            /* if (pythonIsOk)
            {
                CommandResult resultPythonCommand = await runner.ExecuteCommandAsync("cmd.exe", commands.CreateVenv);
                Console.WriteLine(resultPythonCommand.Error);
            } */
        }
    }
}