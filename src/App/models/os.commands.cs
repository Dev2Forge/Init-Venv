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
 * Last Modified: Thursday, 20th November 2025 2:59:44 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using System.Reflection;
using InitVenv.src.App.utils;

namespace InitVenv.src.App.models
{
    public abstract class IOsCommands()
    {
        public abstract string PipPaths { get; }
        public abstract string PythonPaths { get; }
        public abstract string ActivateVenv { get; }
        public abstract string RequirementsInstall { get; }
        public abstract string CheckRequirementsPip { get; }
        public override string ToString()
        {
            string response = @$"OS Commands:
            Pip Paths: {this.PipPaths}
            Python Paths: {this.PythonPaths}
            Create Venv: {this.CreateVenv}
            Activate Venv: {this.ActivateVenv}
            Requirements Install: {this.RequirementsInstall}
            Check Requirements Pip: {this.CheckRequirementsPip}";
            return response;

        }

        public static T Create<T>() where T : IOsCommands, new() => new();

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