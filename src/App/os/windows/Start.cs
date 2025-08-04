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
 * Last Modified: Sunday, 3rd August 2025 8:52:37 pm
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
            // --------- Get the absolute path (if is relative...) ---------
            path = Paths.AbsoluteUniversalPath(path);

            // --------- Objects instances ---------
            WindowsRunner runner = new(path);
            Validators validators = new(runner);
            Commands commands = new();


            // --------- Check that path is OK ---------
            CheckPath(validators, path);

            // --------- Go to the working path/directory ---------
            // CdToWorkingDir(runner, path);

            // --------- Try make the .venv folder ---------
            await TryCreateVenv(validators, runner, commands, path);


            // --------- Try install requirements.txt ---------
            await TryInstallRequirements(validators, runner, commands, path);

            // --------- Try activate venv (in User Terminal and Kepp it!) ---------
            await TryActivateVenv(validators, runner, commands, path);
        }

        private static void CheckPath(Validators v, string p)
        {
            if (!v.CheckWorkingDirExists(p))
            {
                throw new ArgumentException($"The path ({p}) is not valid!");
            }
        }

        /* private static async void CdToWorkingDir(WindowsRunner r, string p)
        {
            CommandResult result = await r.ExecuteCommandAsync("cmd.exe", $"cd /d {p}");

            if (!result.Error.Trim().Equals(""))
            {
                throw new Exception("Please, validate that the path exists and its name is correct");
            }
        } */

        private static async Task TryCreateVenv(Validators v, WindowsRunner r, Commands c, string p)
        {
            // --------- Validations python and existing venv ---------
            bool pythonIsOk = await v.CheckPythonPaths();

            // Local variables
            bool venvExists = CheckVenvExists(p);
            Console.WriteLine($"The virtual venv exists? => {venvExists}");

            // Create the new virtualvenv
            if (!venvExists && pythonIsOk)
            {
                // TODO: Send Succefully message when completed (.ContinueWith)
                await r.ExecuteCommandAsync("cmd.exe", c.CreateVenv);
            }
        }

        private static async Task TryActivateVenv(Validators v, WindowsRunner r, Commands c, string p)
        {
            bool pythonIsOk = await v.CheckPythonPaths();

            if (pythonIsOk)
            {
                // Try activate venv
                await r.ExecuteCommandAsync("cmd.exe", c.ActivateVenv, true, true, false);
            }
        }

        private static async Task TryInstallRequirements(Validators v, WindowsRunner r, Commands c, string p)
        {
            bool pipIsOk = await v.CheckPipPaths();
            bool fileRequirementsExists = v.CheckRequirementsFile(p);

            // Try install the requirements from file
            if (pipIsOk && fileRequirementsExists)
            {
                // TODO: Send Succefully message when completed (.ContinueWith)
                await r.ExecuteCommandAsync("cmd.exe", $"cd /d {p} && {c.ActivateVenv} && {c.RequirementsInstall}");
            }
        }

        /// <summary>
        /// Check if the user have a virtual venv
        /// </summary>
        /// <returns>A bool that indicate if the virtual venv exists</returns>
        private static bool CheckVenvExists(string p)
        {
            string[] venvNames = ["venv", ".venv", "env", ".env", "virtualenv", ".virtualenv", "python-env", ".python-env", "myenv", "project-env", "dev-env", ".dev-env", "local-env", ".local-env"];
            bool venvExist = false;

            // Check if a virtual venv already exists
            foreach (string name in venvNames)
            {
                string absPath = Paths.AbsoluteUniversalPath($"{p}\\{name}\\Scripts\\python.exe");
                // Any virtual venv contains it
                venvExist = Files.Exists(absPath);

                if (venvExist) break;
            }

            return venvExist;
        }
    }
}