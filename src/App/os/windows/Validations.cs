/*
 * windows - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Validations.cs
 * Created: Monday, 28th July 2025 3:15:01 pm
 * -----
 * Last Modified: Thursday, 20th November 2025 2:53:41 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;
using InitVenv.src.App.os.windows.models;
using InitVenv.src.App.utils;

namespace InitVenv.src.App.os.windows
{
    class Validators(WindowsRunner runner, string path) : IOsValidators
    {
        private readonly Commands _commands = new();
        private readonly WindowsRunner _Runner = runner;
        private readonly string workingDir = path;

        public async Task<bool> CheckPipPaths()
        {
            bool ok = false;
            CommandResult commandResult = await this._Runner.ExecuteCommandAsync("cmd.exe", this._commands.PipPaths);

            if (commandResult.ExitCode == 0) { ok = true; }

            return ok;
        }

        public async Task<bool> CheckPythonPaths(bool existVenv = false)
        {
            bool ok = false;
            CommandResult commandResult;

            if (existVenv)
            {
                commandResult = await this._Runner.ExecuteCommandAsync("cmd.exe", $"cd /d {this.workingDir} && {this._commands.ActivateVenv} && {this._commands.PythonPaths}");
                if (commandResult.Output.Contains(".venv\\Scripts\\python.exe")) { ok = true; }
            }
            else
            {
                commandResult = await this._Runner.ExecuteCommandAsync("cmd.exe", $"cd /d {this.workingDir} && {this._commands.PythonPaths}");
                if (commandResult.ExitCode == 0) { ok = true; }
            }
            return ok;
        }
        
        public async Task<bool> CheckRequirementsPip()
        {
            bool ok = false;
            CommandResult commandResult = await this._Runner.ExecuteCommandAsync("cmd.exe", $"cd /d {this.workingDir} && {this._commands.ActivateVenv} && {this._commands.CheckRequirementsPip}");

            if (commandResult.ExitCode == 0) { ok = true; }
            return ok;
        }

        public bool CheckRequirementsFile()
        {
            bool ok = Files.Exists($"{this.workingDir}\\requirements.txt");
            return ok;
        }

        public bool CheckWorkingDirExists()
        {
            bool ok = Files.Exists(this.workingDir);
            return ok;
        }
    }
}