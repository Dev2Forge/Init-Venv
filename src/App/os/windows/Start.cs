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
 * Last Modified: Tuesday, 29th July 2025 8:23:36 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.os.windows.models;
using InitVenv.src.App.utils;

namespace InitVenv.src.App.os.windows
{
    public class WindowsInit
    {
        public static async Task Run(string path)
        {
            // --------- Objects instances ---------
            WindowsRunner runner = new();
            Validators validators = new(runner);
            Commands commands = new();

            // --------- Get the absolute path (if is relative...) ---------
            path = Paths.AbsoluteUniversalPath(path);

            // --------- Check that path is OK ---------
            CheckPath(validators, path);

            // --------- Go to the working path/directory ---------
            CdToWorkingDir(runner, path);


            // --------- Validations python and requirements ---------
            bool pythonIsOk = await validators.CheckPythonPaths();
            bool pipIsOk = await validators.CheckPipPaths();
            bool requirementsIsOk = validators.CheckRequirementsFile();

            // --------- Commands Executions ---------
            // --------- Python Exists ---------
            if (pythonIsOk)
            {
                CommandResult resultPythonCommand = await runner.ExecuteCommandAsync("cmd.exe", commands.CreateVenv);
                Console.WriteLine(resultPythonCommand.Error);
            }
        }

        private static void CheckPath(Validators v, string p)
        {
            if (!v.CheckWorkingDirExists(p))
            {
                throw new ArgumentException($"The path ({p}) is not valid!");
            }
        }

        private static async void CdToWorkingDir(WindowsRunner r, string p)
        {
            CommandResult result = await r.ExecuteCommandAsync("cmd.exe", $"cd /d {p}");

            if (!result.Error.Trim().Equals(""))
            {
                throw new Exception("Please, validate that the path exists and its name is correct");
            }
        }
    }
}