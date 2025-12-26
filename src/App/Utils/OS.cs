/*
 * Utils - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \OS.cs
 * Created: Friday, 18th July 2025 7:00:41 pm
 * -----
 * Last Modified: Thursday, 25th December 2025 9:44:27 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

namespace InitVenv.src.App.utils
{
    public class OS
    {
        public static string? GetOS()
        {
            string? os = null;

            if (OperatingSystem.IsLinux()) os = "Linux";
            if (OperatingSystem.IsWindows()) os = "Windows";
            if (OperatingSystem.IsMacOS()) os = "MacOS";

            return os;
        }

        public static string GetOSTypeID()
        {
            Dictionary<string, string> fileData = Files.ParseOSReleaseToDictionary();
            string osTypeID = $"{fileData!.GetValueOrDefault("ID", null)}";
            
            return osTypeID;
        }

        public static string GetCurrentDesktopEnvironment()
        {
            string desktopEnvironment = Environment.GetEnvironmentVariable("XDG_CURRENT_DESKTOP") ?? throw new Exception("Don't exists the 'XDG_CURRENT_DESKTOP' environment variable");

            return desktopEnvironment.ToLower();
        }
    }
}