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
 * Last Modified: Sunday, 27th July 2025 8:40:06 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using System.Reflection;
using InitVenv.src.App.utils;

namespace InitVenv.src.App.models
{
    public abstract class IOsCommands()
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
        /// <returns>A object with the OS commands (Object type "T")</returns>
        public static T LoadConfigs<T>() where T : IOsCommands
        {
            string OSName = typeof(T).Name.Replace("Commands", "");
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

        /// <summary>
        /// Get the properties of this Object
        /// </summary>
        /// <returns>A string array that contains all object properties</returns>
        /// <exception cref="Exception"></exception>
        public static string[] Properties()
        {
            PropertyInfo[] props = typeof(IOsCommands).GetProperties();
            string[] propStrings = new string[props.Length];
            if (props != null)
            {
                for (int i = 0; i < props.Length; i++)
                {
                    propStrings[i] = props[i].Name;
                }

                return propStrings;
            }
            throw new Exception("Error trying get properties");
        }

        public static string GetProperty(IOsCommands instance, string property)
        {
            string? value = typeof(IOsCommands).GetProperty(property)?.GetValue(instance)?.ToString();

            if (value != null) return value;

            throw new Exception("It was not possible to obtain the value of the property");
        }
    }
}