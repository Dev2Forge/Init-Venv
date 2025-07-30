/*
 * models - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \WindowsCommandsResult.cs
 * Created: Sunday, 27th July 2025 8:42:24 pm
 * -----
 * Last Modified: Monday, 28th July 2025 3:12:01 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using System.Collections;

namespace InitVenv.src.App.os.windows.models
{
    public class CommandResult
    {
        public bool Success { get; set; }
        public string Output { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
        public int ExitCode { get; set; }
        public IDictionary? ExceptionData { get; set; }
    }
}