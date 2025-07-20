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
 * Last Modified: Saturday, 19th July 2025 10:54:57 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.models
{
    public class WindowsCommands
    {
        // On windows, command to show the "pip" path (Where)
        public required string PipPaths { get; set; }
        // On windows, command to show the "python" path (Where)
        public required string PythonPaths { get; set; }
        // On windows 10/11, command to create new "venv"
        public required string CreateVenv { get; set; }
        // On windows 10/11, is used to activate the venv (usally is ".\venv\Scripts\activate)
        public required string ActivateVenv { get; set; }
        // In windows, usually is "pip -r requirements.txt"
        public required string RequirementsInstall { get; set; }
    }
}