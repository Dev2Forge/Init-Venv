/*
 * models - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \os.commands.cs
 * Created: Sunday, 20th July 2025 12:32:02 am
 * -----
 * Last Modified: Sunday, 20th July 2025 3:32:49 am
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.Utils;

namespace InitVenv.src.App.models
{
    public class IOsCommands()
    {
        /// <summary>
        /// On windows, command to show the "pip"
        /// </summary>
        public required string PipPaths { get; set; }
        /// <summary>
        /// Find out the route of the "python"
        /// </summary>
        public required string PythonPaths { get; set; }
        /// <summary>
        /// Command to create new "venv"
        /// </summary>
        public required string CreateVenv { get; set; }
        /// <summary>
        /// Is used to activate the venv (usally is ".\venv\Scripts\activate" on Windows)
        /// </summary>
        public required string ActivateVenv { get; set; }
        /// <summary>
        /// Usually is "pip -r requirements.txt"
        /// </summary>
        public required string RequirementsInstall { get; set; }

        /// <summary>
        /// Load the configs for the OS
        /// </summary>
        /// <typeparam name="T">The class Type</typeparam>
        /// <returns></returns>
        public static T LoadConfigs<T>(string OSName) where T : IOsCommands
        {
            T configs = Files.ReadJSON<T>($"./src/App/configs/commands/{OSName}.jsonc");
            return configs;
        }

        public override string ToString()
        {
            string response = @$"OS Commands:
            Pip Paths: {this.PipPaths}
            Python Paths: {this.PythonPaths}
            Create Venv: {this.CreateVenv}
            Activate Venv: {this.ActivateVenv}
            Requirements Install: {this.RequirementsInstall}";
            return response;

        }
    }
}