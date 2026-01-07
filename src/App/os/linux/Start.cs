/*
 * linux - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Start.cs
 * Created: Sunday, 27th July 2025 8:31:25 pm
 * -----
 * Last Modified: Tuesday, 6th January 2026 9:08:39 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.os.linux.models;
using InitVenv.src.App.utils;

namespace InitVenv.src.App.os.linux
{
    public class LinuxInit
    {
        public static async Task Run(string path)
        {
            path = Paths.AbsoluteUniversalPath(path);
            
            LinuxRunner runner = new(path);
            string venvName = runner.FindActualVenvName(path) ?? ".venv";
            Validators validators = new(runner, path, venvName);
            CommandsLinux commands = new(venvName);

            CheckPath(validators, path);
            
            bool venvIsOld = await TryCreateVenv(validators, runner, commands, path);
            await TryInstallRequirements(validators, runner, commands, path, venvIsOld);
            await TryActivateVenv(validators, runner, commands, path, venvName);
        }

        private static void CheckPath(Validators v, string p)
        {
            if (!v.CheckWorkingDirExists())
            {
                throw new ArgumentException($"The path ({p}) is not valid!");
            }
        }

        private static async Task<bool> TryCreateVenv(Validators v, LinuxRunner r, CommandsLinux c, string p)
        {
            bool venvExists = CheckVenvExists(p, r);
            bool pythonIsOk = await v.CheckPythonPaths(venvExists);

            if (!venvExists && pythonIsOk)
            {
                await r.ExecuteCommandAsync(c.CreateVenv);
            }

            return venvExists;
        }

        private static async Task TryActivateVenv(Validators v, LinuxRunner r, CommandsLinux c, string p, string venvName)
        {
            bool pythonIsOk = await v.CheckPythonPaths(true);
            string _showVenvContentToUser = "echo -e '\\n---- Python Paths ----\\n' && which python3 && echo -e '\\n---- PIP Paths ----\\n' && which pip3 && echo -e '\\n---- Requirements list ----\\n' && pip3 list && echo -e '----------------------\\n\\n'";

            if (pythonIsOk)
            {
                await r.ExecuteCommandAsync($"{c.ActivateVenv} && {_showVenvContentToUser}");
                
                Environment.SetEnvironmentVariable("INIT_VENV_PATH", p);
                Environment.SetEnvironmentVariable("INIT_VENV_NAME", venvName);
                Environment.SetEnvironmentVariable("VIRTUAL_ENV_DISABLE_PROMPT", "0");
                
                await r.ExecuteCommandAsync("echo 'Interactive shell with venv'", keep: true);
            }
        }

        private static async Task TryInstallRequirements(Validators v, LinuxRunner r, CommandsLinux c, string p, bool isOldVenv)
        {
            string completeCommand = $"cd {p} && {c.ActivateVenv} && {c.RequirementsInstall}";
            bool pipIsOk = await v.CheckPipPaths();
            
            bool fileRequirementsExists = v.CheckRequirementsFile();
            bool requirementsIsInstall;

            if (!fileRequirementsExists)
            {
                Console.WriteLine("[ INFO ] The requirements file don't exists.");
                return;
            }

            if (!pipIsOk)
            {
                throw new Exception("[ INFO ] The pip paths aren't OK.");
            }

            if (!isOldVenv)
            {
                await r.ExecuteCommandAsync(completeCommand, false);
            }
            else
            {
                requirementsIsInstall = await v.CheckRequirementsPip();
                if (!requirementsIsInstall)
                {
                    await r.ExecuteCommandAsync(completeCommand);
                }
            }
        }

        private static bool CheckVenvExists(string p, LinuxRunner runner)
        {
            bool venvExist = false;

            if (runner.FindActualVenvName(p) != null)
            {
                venvExist = true;
            }
            
            return venvExist;
        }
    }
}
