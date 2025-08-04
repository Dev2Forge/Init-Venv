/*
 * models - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \windows.commands.cs
 * Created: Friday, 18th July 2025 11:51:38 pm
 * -----
 * Last Modified: Sunday, 3rd August 2025 8:58:56 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;

namespace InitVenv.src.App.os.windows.models
{
    public class Commands : IOsCommands
    {
        public override string PipPaths => "where pip";
        public override string PythonPaths { get => "where python"; }
        public override string CreateVenv { get => "python -m venv .venv"; }
        public override string ActivateVenv { get => ".venv\\Scripts\\activate"; }
        public override string RequirementsInstall { get => "pip install -r requirements.txt"; }
        public override string CheckRequirementsPip { get => "pip check"; }

    }
}