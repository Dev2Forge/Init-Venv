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
 * Last Modified: Saturday, 19th July 2025 12:01:55 am
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.models
{
    public class WindowsCommands
    {
        public required string PipPaths { get; set; }
        public required string PythonPaths { get; set; }
        public required string CreateVenv { get; set; }
        public required string ActivateVenv { get; set; }
        public required string RequirementsInstall { get; set; }
    }
}