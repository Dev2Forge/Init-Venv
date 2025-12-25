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
 * Last Modified: Wednesday, 24th December 2025 9:55:17 pm
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
            path = Paths.AbsoluteUniversalPath(path);
            
            WindowsRunner runner = new(path);
            Validators validators = new(runner, path);
            CommandsWindows commands = new();

            CheckPath(validators, path);
            bool venvIsOld = await TryCreateVenv(validators, runner, commands, path);
            await TryInstallRequirements(validators, runner, commands, path, venvIsOld);
            await TryActivateVenv(validators, runner, commands, path);
        }

        private static void CheckPath(Validators v, string p)
        {
            if (!v.CheckWorkingDirExists())
            {
                throw new ArgumentException($"The path ({p}) is not valid!");
            }
        }

        private static async Task<bool> TryCreateVenv(Validators v, WindowsRunner r, CommandsWindows c, string p)
        {
            bool venvExists = CheckVenvExists(p);
            bool pythonIsOk = await v.CheckPythonPaths(venvExists);

            if (!venvExists && pythonIsOk)
            {
                await r.ExecuteCommandAsync("cmd.exe", c.CreateVenv);
            }

            return venvExists;
        }

        private static async Task TryActivateVenv(Validators v, WindowsRunner r, CommandsWindows c, string p)
        {
            bool pythonIsOk = await v.CheckPythonPaths(true);
            string _showVenvContentToUser = "echo ----Python Paths---- && where python && echo ----PIP Paths---- && where pip && echo ----Requirements list---- && pip list";

            if (pythonIsOk)
            {
                await r.ExecuteCommandAsync("cmd.exe", $"{c.ActivateVenv} && {_showVenvContentToUser}", true, true, false);
            }
        }

        private static async Task TryInstallRequirements(Validators v, WindowsRunner r, CommandsWindows c, string p, bool isOldVenv)
        {
            string completeCommand = $"cd /d {p} && {c.ActivateVenv} && {c.RequirementsInstall}";
            bool pipIsOk = await v.CheckPipPaths();
            bool fileRequirementsExists = v.CheckRequirementsFile();
            bool requirementsIsInstall;

            if (pipIsOk && fileRequirementsExists)
            {
                if (!isOldVenv)
                {
                    await r.ExecuteCommandAsync("cmd.exe", completeCommand);
                }
                else
                {
                    requirementsIsInstall = await v.CheckRequirementsPip();

                    if (!requirementsIsInstall)
                    {
                        await r.ExecuteCommandAsync("cmd.exe", completeCommand);
                    }
                }
            }
        }

        private static bool CheckVenvExists(string p)
        {
            string[] venvNames = ["venv", ".venv", "env", ".env", "virtualenv", ".virtualenv", "python-env", ".python-env", "myenv", "project-env", "dev-env", ".dev-env", "local-env", ".local-env"];
            bool venvExist = false;
            
            // TODO: Upgrade from for to while! (Not use Break!)
            foreach (string name in venvNames)
            {
                string absPath = Paths.AbsoluteUniversalPath($"{p}\\{name}\\Scripts\\python.exe");
                venvExist = Files.Exists(absPath);

                if (venvExist) break;
            }
            
            return venvExist;
        }
    }
}
