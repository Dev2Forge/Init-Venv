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
 * Last Modified: Tuesday, 5th August 2025 7:26:14 pm
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
        /// <param name="workingDir">The path to the working directory</param>
        /// <returns>A bool that represents if <strong>requirements.txt</strong> exists</returns>
        public abstract bool CheckRequirementsFile(string workingDir);
        /// <summary>
        /// Check that <strong>dependencies</strong> already install in the <strong>.venv</strong> directory
        /// </summary>
        /// <param name="workingDir">The path to the working directory</param>
        /// <returns>A bool that represents if missing some <strong>dependencies</strong></returns>
        public abstract Task<bool> CheckRequirementsPip(string workingDir);
        /// <summary>
        /// Validate that the string path of working directory is valid and exists
        /// </summary>
        /// <param name="path">The path to the working directory</param>
        /// <returns>A bool that represents if <strong>workin directory path</strong> exists and is valid</returns>
        public abstract bool CheckWorkingDirExists(string path);
    }
}