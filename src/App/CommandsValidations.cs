/*
 * App - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Validations.cs
 * Created: Sunday, 27th July 2025 2:17:40 pm
 * -----
 * Last Modified: Sunday, 27th July 2025 3:28:57 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using InitVenv.src.App.models;

namespace App
{
    internal static class Validations
    {
        public static void CheckPythonInstallation()
        {
        }

        public static void CheckVirtualEnvInstallation()
        {
            // Logic to check if virtualenv is installed
            Console.WriteLine("Checking virtualenv installation...");
            // Simulate check
            bool isVirtualEnvInstalled = true; // Replace with actual check logic
            if (isVirtualEnvInstalled)
            {
                Console.WriteLine("virtualenv is installed.");
            }
            else
            {
                Console.WriteLine("virtualenv is not installed. Please install virtualenv.");
                Environment.Exit(1);
            }
        }
    }
}