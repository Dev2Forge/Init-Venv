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
 * Last Modified: Wednesday, 6th August 2025 5:42:27 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

//  TODO: The command to activate the virtual environment
// change for each name (.venv, venv, .env\, virtualenv, etc)
// So, the name of virtual venv should be obtained to use it!
// Can be in the "checkVenvExists" function...

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

            // --------- Try make the .venv folder ---------
            bool venvIsOld = await TryCreateVenv(validators, runner, commands, path);

            // --------- Try install requirements.txt ---------
            await TryInstallRequirements(validators, runner, commands, path, venvIsOld);

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

        private static async Task<bool> TryCreateVenv(Validators v, WindowsRunner r, Commands c, string p)
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

            return venvExists;
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

        private static async Task TryInstallRequirements(Validators v, WindowsRunner r, Commands c, string p, bool isOldVenv)
        {
            string completeCommand = $"cd /d {p} && {c.ActivateVenv} && {c.RequirementsInstall}";
            bool pipIsOk = await v.CheckPipPaths();
            bool fileRequirementsExists = v.CheckRequirementsFile(p);
            bool requirementsIsInstall;

            // Try install the requirements from file
            if (pipIsOk && fileRequirementsExists)
            {
                // All requirements will be install
                if (!isOldVenv)
                {
                    // TODO: Send Succefully message when completed (.ContinueWith)
                    await r.ExecuteCommandAsync("cmd.exe", completeCommand);
                }
                else
                {
                    // Check if missing any requirement and try fix (Re-Install)
                    requirementsIsInstall = await v.CheckRequirementsPip(p);
                    Console.WriteLine($"Req are installed? => {requirementsIsInstall}");

                    if (!requirementsIsInstall)
                    {
                        await r.ExecuteCommandAsync("cmd.exe", completeCommand);
                    }
                }
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