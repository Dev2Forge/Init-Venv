/*
 * Init-Venv - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Program.cs
 * Created: Friday, 18th July 2025 7:00:41 pm
 * -----
 * Last Modified: Friday, 26th December 2025 2:13:40 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using App;
using InitVenv.src.App.utils;

namespace InitVenv
{
    class App
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("---------\nInit-Venv (C) 2025 - Dev2Forge\nAll Rights Reserved.\n---------\n");

            try
            {
                if (!(args.Length > 0))
                {
                    throw new ArgumentException("The working directory could not be obtained.");
                }

                if (args[0].Length < 1)
                {
                    throw new ArgumentException("The path to the directory is not valid or incorrect.");
                }

                await Init.Run(args[0]).ContinueWith(t => WaitCloseOnlyWindows(t: t));
            }
            catch (Exception e)
            {
                WaitCloseOnlyWindows(msg: $"[ERROR]  {e.Message}\n\nPlease, try execute again...");
            }

        }

        private static void FinishProgram(Task? t, string? msg)
        {
            string message = msg ?? "";
            
            if (msg == null && t != null)
            {
                message = t.IsCompleted ? "Program exit Sucessfully!" : "Program exit with Errors";
            }

            Console.Write($"{message}\nPress ENTER to close...");
            Console.Read();   
        }

        private static void WaitCloseOnlyWindows(Task? t = null, string? msg = null)
        {
            if(OS.GetOS() == "windows")
            {
                FinishProgram(t, msg);
            }
        }
    }
}