/*
 * models - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \os.validators.cs
 * Created: Monday, 28th July 2025 3:17:00 pm
 * -----
 * Last Modified: Thursday, 20th November 2025 3:00:03 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.models
{
    interface IOsValidators
    {
        public abstract Task<bool> CheckPythonPaths(bool existVenv = false);
        public abstract Task<bool> CheckPipPaths();
        public abstract bool CheckRequirementsFile();
        public abstract Task<bool> CheckRequirementsPip();
        public abstract bool CheckWorkingDirExists();
    }
}