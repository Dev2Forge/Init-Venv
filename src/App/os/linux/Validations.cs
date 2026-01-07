/*
 * linux - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Validations.cs
 * Created: Monday, 28th July 2025 3:15:01 pm
 * -----
 * Last Modified: Wednesday, 7th January 2026 11:08:08 am
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;
using InitVenv.src.App.os.linux.models;
using InitVenv.src.App.utils;

namespace InitVenv.src.App.os.linux
{
    class Validators(LinuxRunner runner, string path, string venvName) : IOsValidators
    {
        private readonly CommandsLinux _commands = new(venvName);
        private readonly LinuxRunner _Runner = runner;
        private readonly string workingDir = path;
        private readonly string venvName = venvName;
        public async Task<bool> CheckPipPaths()
        {
            bool ok = false;
            CommandResult commandResult = await this._Runner.ExecuteCommandAsync($"cd {this.workingDir} && {this._commands.ActivateVenv} && {this._commands.PipPaths}");
            
            if (commandResult.Output.Contains($"{this.venvName}/bin/pip3")){ ok = true; }

            return ok;
        }

        public async Task<bool> CheckPythonPaths(bool existVenv = false)
        {
            bool ok = false;
            CommandResult commandResult;

            if (existVenv)
            {
                if (this._Runner.FindActualVenvName(this.workingDir) != null) { ok = true; }
            }
            else
            {
                // Check if exist python on the system
                commandResult = await this._Runner.ExecuteCommandAsync($"cd {this.workingDir} && {this._commands.PythonPaths}");
                if (commandResult.ExitCode == 0) { ok = true; }
            }
            return ok;
        }
        
        public async Task<bool> CheckRequirementsPip()
        {
            bool ok = false;
            CommandResult commandResult = await this._Runner.ExecuteCommandAsync($"cd {this.workingDir} && {this._commands.ActivateVenv} && {this._commands.CheckRequirementsPip}");
            if (commandResult.ExitCode == 0) { ok = true; }
            return ok;
        }

        public bool CheckRequirementsFile()
        {
            bool ok = Files.Exists($"{this.workingDir}/requirements.txt");
            return ok;
        }

        public bool CheckWorkingDirExists()
        {
            bool ok = Files.Exists(this.workingDir);
            return ok;
        }
    }
}