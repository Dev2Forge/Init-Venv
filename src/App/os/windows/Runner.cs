/*
 * windows - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Runner.cs
 * Created: Monday, 28th July 2025 2:36:53 pm
 * -----
 * Last Modified: Thursday, 20th November 2025 2:58:49 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using System.Diagnostics;
using System.Text;
using InitVenv.src.App.os.windows.models;

namespace InitVenv.src.App.os.windows
{
    class WindowsRunner(string path)
    {
        private readonly string workingDir = path;
        public async Task<CommandResult> ExecuteCommandAsync(string filename, string command, bool keep = false, bool userShell = false, bool wait = true)
        {
            string ConsoleKeep = keep ? "/k" : "/c";

            Console.WriteLine($"[ INFO ] Try executing command: \"{command}\"");

            try
            {
                using Process process = new();
                process.StartInfo.WorkingDirectory = this.workingDir;
                process.StartInfo.UseShellExecute = userShell;
                process.StartInfo.FileName = filename;
                process.StartInfo.Arguments = $"{ConsoleKeep} {command}";

                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();
                
                if (!userShell)
                {
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            outputBuilder.AppendLine(e.Data);
                            Console.WriteLine($"[ OUT  ] {e.Data}");
                        }
                    };

                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            errorBuilder.AppendLine(e.Data);
                            Console.WriteLine($"[ ERROR] {e.Data}");
                        }
                    };
                }

                process.Start();

                if (!userShell)
                {
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                }

                int exitCode = 0;
                if (wait)
                {
                    await process.WaitForExitAsync();
                    exitCode = process.HasExited ? process.ExitCode : 0;
                }
                else
                {
                    process.Close();
                }

                string output = outputBuilder.ToString();
                string error = errorBuilder.ToString();

                bool hasErrors = userShell ? false : (exitCode != 0 || !string.IsNullOrEmpty(error));
                
                if (userShell)
                {
                    Console.WriteLine("[ INFO ] Command executed with shell (output not captured)");
                }
                else if (hasErrors)
                {
                    Console.WriteLine($"[ WARN ] Completed with errors (Exit Code: {exitCode})");
                    if (!string.IsNullOrEmpty(error))
                    {
                        Console.WriteLine($"Errores: {error}");
                    }
                }
                else
                {
                    Console.WriteLine("[ INFO ] Operation successfully!");
                }

                return new CommandResult
                {
                    Success = !hasErrors,
                    Output = output,
                    Error = error,
                    ExitCode = exitCode
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]  Caused by: {ex.Message}");
                return new CommandResult
                {
                    Success = false,
                    Error = ex.Message,
                    ExceptionData = ex.Data,
                    ExitCode = -1
                };
            }
        }
    }
}