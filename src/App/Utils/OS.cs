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
 * Last Modified: Wednesday, 24th December 2025 10:43:04 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using System.Runtime.InteropServices;

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

        public static string? GetOSInformation()
        {
            string? info = "";

            // info += $"OSDescription: {RuntimeInformation.OSDescription}\n";
            // info += $"OSArchitecture: {RuntimeInformation.OSArchitecture}\n";
            // info += $"ProcessArchitecture: {RuntimeInformation.ProcessArchitecture}\n";
            // info += $"FrameworkDescription: {RuntimeInformation.FrameworkDescription}\n";
            // info += $"RuntimeIdentifier: {RuntimeInformation.RuntimeIdentifier}\n";
            // info += $"Platform: {Environment.OSVersion.Platform}\n";
            // info += $"GetType: {Environment.OSVersion.GetType()}\n";
            // info += $"Version: {Environment.OSVersion.Version}\n";
            // info += $"VersionString: {Environment.OSVersion.VersionString}\n";
            // info += $"OSVersion: {Environment.OSVersion}\n";


            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var distroInfo = File.ReadAllText("/etc/os-release");
                // Parsear las variables PRETTY_NAME, ID, VERSION_ID, etc.
                info += distroInfo;
            }
            return info;
        }
    }
}