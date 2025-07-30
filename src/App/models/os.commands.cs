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
 * Last Modified: Monday, 28th July 2025 2:53:08 pm
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
        public abstract string PipPaths { get; }
        /// <summary>
        /// Find out the route of the "python"
        /// </summary>
        public abstract string PythonPaths { get; }
        /// <summary>
        /// Command to create new "venv"
        /// </summary>
        public abstract string CreateVenv { get; }
        /// <summary>
        /// Is used to activate the venv (usally is ".\venv\Scripts\activate" on Windows)
        /// </summary>
        public abstract string ActivateVenv { get; }
        /// <summary>
        /// Usually is "pip -r requirements.txt"
        /// </summary>
        public abstract string RequirementsInstall { get; }
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

        public static T Create<T>() where T : IOsCommands, new() => new();

        /// <summary>
        /// Get the properties of this Object
        /// </summary>
        /// <returns>A string array that contains all object properties</returns>
        /// <exception cref="Exception"></exception>
        public string[] Properties()
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

        public string GetProperty(IOsCommands instance, string property)
        {
            string? value = typeof(IOsCommands).GetProperty(property)?.GetValue(instance)?.ToString();

            if (value != null) return value;

            throw new Exception("It was not possible to obtain the value of the property");
        }
    }
}