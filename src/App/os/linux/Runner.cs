/*
 * linux - Initialize a virtual environment automatically
 * Copyright 2025 - 2025 Dev2Forge
 * Licence: GPL-3
 * More information: https://github.com/Dev2Forge/Init-Venv/blob/main/LICENSE
 * Author: tutosrive (tutosrive@Dev2Forge.software)
 * 
 * File: \Runner.cs
 * Created: Monday, 28th July 2025 2:36:53 pm
 * -----
 * Last Modified: Tuesday, 6th January 2026 8:21:47 pm
 * Modified By: tutosrive (tutosrive@Dev2Forge.software)
 * -----
 */

using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using InitVenv.src.App.models;

namespace InitVenv.src.App.os.linux
{
    class LinuxRunner(string path)
    {
        private readonly string workingDir = path;

        [DllImport("libc.so.6")]
        private static extern int execvp(IntPtr file, IntPtr[] argv);

        public async Task<CommandResult> ExecuteCommandAsync(string command, bool keep = false)
        {
            Console.WriteLine($"[ INFO ] Try executing command: \"{command}\"");

            try
            {
                using Process process = new();
                process.StartInfo.WorkingDirectory = this.workingDir;
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{command}\"";

                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                StringBuilder errors = new();
                StringBuilder outputs = new();

                process.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        outputs.AppendLine(e.Data);
                        Console.WriteLine($"[ OUT  ] {e.Data}");
                    }
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        errors.AppendLine(e.Data);
                        Console.WriteLine($"[ ERROR] {e.Data}");
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();

                string output = outputs.ToString();
                string error = errors.ToString();
                int exitCode = process.ExitCode;
                bool hasErrors = !string.IsNullOrEmpty(error);

                CommandResult result = new()
                {
                    Success = !hasErrors,
                    Output = output,
                    Error = error,
                    ExitCode = exitCode
                };

                if (keep)
                {
                    this.StartInteractiveShellWithVenv(this.workingDir);
                }

                return result;
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

        public void StartInteractiveShellWithVenv(string venvPath)
        {
            string? venvName = this.FindActualVenvName(this.workingDir);
            if (venvName == null)
            {
                Console.WriteLine("[WARN] No se encontró entorno virtual, usando shell normal");
                venvName = ".venv";
            }

            string initScript = this.CreateVenvInitScript(this.workingDir, venvName);

            this.LaunchInteractiveBashWithInitScript(initScript);
        }

        public string? FindActualVenvName(string directory)
        {
            string[] venvNames = ["venv", ".venv", "env", ".env", "virtualenv", ".virtualenv",
                                  "python-env", ".python-env", "myenv", "project-env",
                                  "dev-env", ".dev-env", "local-env", ".local-env"];

            foreach (string name in venvNames)
            {
                string activatePath = Path.Combine(directory, name, "bin", "activate");
                if (File.Exists(activatePath))
                {
                    return name;
                }
            }
            return null;
        }

        public string CreateVenvInitScript(string workingDir, string venvName)
        {
            string tempFile = Path.GetTempFileName();

            string scriptContent = "#!/bin/bash\n" +
                "cd '" + workingDir + "'\n" +
                "\n" +
                "if [ -f '" + venvName + "/bin/activate' ]; then\n" +
                "    source '" + venvName + "/bin/activate'\n" +
                "    echo \"[ INFO ] Virtual environment activated: $(which python3)\"\n" +
                "else\n" +
                "    echo '[ ERROR ] Do not activate virtual environment'\n" +
                "fi\n" +
                "\n" +
                "if [ -f ~/.bashrc ]; then\n" +
                "    source ~/.bashrc\n" +
                "fi\n" +
                "\n" +
                "if [ -n \"$VIRTUAL_ENV\" ]; then\n" +
                "    if [[ ! \"$PS1\" =~ \"($(basename \"$VIRTUAL_ENV\"))\" ]]; then\n" +
                "        export PS1=\"($(basename \"$VIRTUAL_ENV\"))$PS1\"\n" +
                "    fi\n" +
                "fi\n" +
                "\n" +
                "rm -f '" + tempFile + "'\n";

            File.WriteAllText(tempFile, scriptContent);
            return tempFile;
        }

        private void LaunchInteractiveBashWithInitScript(string initScript)
        {
            string bashCommand = $"--init-file \"{initScript}\" -i";

            IntPtr file = Marshal.StringToHGlobalAnsi("/bin/bash");
            IntPtr arg1 = Marshal.StringToHGlobalAnsi("--init-file");
            IntPtr arg2 = Marshal.StringToHGlobalAnsi(initScript);
            IntPtr arg3 = Marshal.StringToHGlobalAnsi("-i");
            IntPtr[] argv = [file, arg1, arg2, arg3, IntPtr.Zero];

            _ = execvp(file, argv);

            Marshal.FreeHGlobal(file);
            Marshal.FreeHGlobal(arg1);
            Marshal.FreeHGlobal(arg2);
            Marshal.FreeHGlobal(arg3);
        }
    }
}