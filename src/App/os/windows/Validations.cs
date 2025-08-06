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
 * Last Modified: Tuesday, 5th August 2025 7:42:38 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;
using InitVenv.src.App.os.windows.models;
using InitVenv.src.App.utils;

namespace InitVenv.src.App.os.windows
{
    /// <summary>
    /// Check/Validate output commands before create the environment and install something
    /// </summary>
    /// <param name="runner">The Windows Object Runner, to can execute commands with the same instance/reference</param>
    class Validators(WindowsRunner runner) : IOsValidators
    {
        /// <summary>
        /// The windows commands object (Contains all Windows commands - Allowed...)
        /// </summary>
        private readonly Commands _commands = new();
        /// <summary>
        /// The Windows Object Runner, to can execute commands with the same instance/reference
        /// </summary>
        private readonly WindowsRunner _Runner = runner;

        /// <summary>
        /// Validate if <strong>pip</strong> (of python) exists in the system
        /// </summary>
        /// <returns>A bool that indicate if <strong>pip</strong> exists</returns>
        public async Task<bool> CheckPipPaths()
        {
            bool ok = false;
            CommandResult commandResult = await this._Runner.ExecuteCommandAsync("cmd.exe", this._commands.PipPaths);
            if (commandResult.Error.Trim().Equals("")) { ok = true; }
            return ok;
        }

        /// <summary>
        /// Validate if <strong>python</strong> exists in the system
        /// </summary>
        /// <returns>A bool that indicate if <strong>python</strong> exists</returns>
        public async Task<bool> CheckPythonPaths()
        {
            bool ok = false;
            CommandResult commandResult = await this._Runner.ExecuteCommandAsync("cmd.exe", this._commands.PythonPaths);
            if (commandResult.Error.Trim().Equals("")) { ok = true; }
            return ok;
        }

        /// <summary>
        /// Validate if <strong>requirements</strong> already installed in the venv.
        /// See https://pip.pypa.io/en/stable/cli/pip_check/
        /// </summary>
        /// <returns>A bool that indicate if <strong>requirements</strong> already installed</returns>
        public async Task<bool> CheckRequirementsPip(string workingDir)
        {
            // TODO: Debug me!
            bool ok = true;
            CommandResult commandResult = await this._Runner.ExecuteCommandAsync("cmd.exe", $"cd /d {workingDir} && {this._commands.ActivateVenv} && {this._commands.CheckRequirementsPip}");
            if (commandResult.ExitCode == 0) { ok = false; }
            return ok;
        }

        /// <summary>
        /// Validate if <strong>requirements.txt</strong> (of python) exists in the same directory of <strong>.venv</strong> directory
        /// </summary>
        /// <returns>A bool that indicate if <strong>requirements.txt</strong> exists</returns>
        public bool CheckRequirementsFile(string workingDir)
        {
            bool ok = Files.Exists($"{workingDir}\\requirements.txt");
            return ok;
        }

        public bool CheckWorkingDirExists(string path)
        {
            bool ok = Files.Exists(path);
            return ok;
        }
    }
}