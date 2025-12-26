/*
 * models - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: /Commands.cs
 * Created: Wednesday, 31st December 1969 7:00:00 pm
 * -----
 * Last Modified: Friday, 26th December 2025 2:30:48 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;

namespace InitVenv.src.App.os.linux.models
{
    public class CommandsLinux(string venvName) : IOsCommands
    {
        // It could be "python3 -m pip --version"
        public override string PipPaths => "which pip3"; // Not functional ... or relevant in linux
        public override string PythonPaths { get => "which python3"; }
        public override string CreateVenv { get => $"python3 -m venv {venvName}"; }
        // TODO: Accept others environments names ...
        public override string ActivateVenv { get => $"source {venvName}/bin/activate"; }
        public override string RequirementsInstall { get => "pip3 install -r requirements.txt"; }
        public override string CheckRequirementsPip { get => "pip3 check"; }

    }
}