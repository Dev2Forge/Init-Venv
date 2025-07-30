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
 * Last Modified: Monday, 28th July 2025 4:31:30 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.models
{
    interface IOsValidators
    {
        /// <summary>
        /// Check that <strong>python</strong> exixts in the system
        /// </summary>
        /// <returns>A bool that represents if <strong>python</strong> exists</returns>
        public abstract Task<bool> CheckPythonPaths();
        /// <summary>
        /// Check that <strong>pip</strong> exists in the system
        /// </summary>
        /// <returns>A bool that represents if <strong>pip</strong> exists</returns>
        public abstract Task<bool> CheckPipPaths();
        /// <summary>
        /// Check that <strong>requirements.txt</strong> exists in the same <strong>.venv</strong> directory
        /// </summary>
        /// <returns>A bool that represents if <strong>requirements.txt</strong> exists</returns>
        public abstract bool CheckRequirementsFile();
    }
}