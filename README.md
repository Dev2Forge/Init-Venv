# InitVenv

## Table of Contents
- [🚀 Features](#features)
- [📋 Requirements](#requirements) 
- [🛠️ Installation](#installation)
- [📖 Usage](#usage)
- [🔧 How It Works](#how-it-works)
- [📸 Screenshots](#screenshots)
- [⚠️ Important Notes](#important-notes)
- [🤝 Contributing](#contributing)
- [📝 License](#license)
- [🔗 Links](#links)
- [👨‍💻 Contributors](#contributors)

**InitVenv** is a cross-platform automation tool that streamlines Python development workflow by automatically creating Python virtual environments, installing project dependencies from `requirements.txt`, and activating the environment with a single command execution. Currently supports Windows, with Linux and macOS support planned for future releases.

## Features

- **One-command setup**: Create Python virtual environment, install requirements, and activate with a single command
- **Windows integration**: Works seamlessly with Windows File Explorer
- **Automatic detection**: Finds and installs requirements from `requirements.txt` automatically
- **Path flexibility**: Supports both absolute and relative paths
- **Zero configuration**: Just run and go

## Requirements

- Python installed and added to system PATH
- Windows operating system (currently Windows-only)

## Installation

1. Download the latest [release](https://github.com/Dev2Forge/Init-Venv/releases)
2. Run the installer
3. The installer will:
   - Copy `InitVenv-{architecture}.exe` and `InitVenv.bat` to your chosen directory
   - Add the installation directory to system PATH

## Usage

### Method 1: Windows File Explorer (Recommended)

1. Navigate to your project directory using Windows File Explorer
2. Create a `requirements.txt` file with your Python dependencies
3. Press <kbd>Ctrl</kbd> + <kbd>L</kbd> to activate the address bar
4. Type `InitVenv` and press Enter
5. The program will automatically create the virtual environment and install dependencies

### Method 2: Command Line

```bash
InitVenv "C:\path\to\your\project"
```

You can use both absolute and relative paths:
```bash
InitVenv ".\my-project"
InitVenv ".."
```

## How It Works

The installer creates a simple batch file that launches the main executable:

```batch
@echo off
start "" "InitVenv-x64.exe" "%CD%"
exit
```

When you run `InitVenv`, it:
1. Detects the current directory
2. Creates a Python virtual environment (`.venv`)
3. Activates the virtual environment
4. Installs packages from `requirements.txt` (if present)
5. Keeps the terminal open for continued work

## Screenshots

| Scenario | Preview |
| :------- | :------ |
| Program startup error - missing working directory | <img width="680" height="412" alt="Program startup error showing missing working directory configuration" src="https://github.com/user-attachments/assets/8b4243a0-4c83-4956-b5e6-7a02d92135bb" /> |
| Successful program initialization without requirements file | <img width="976" height="513" alt="Program successfully started without requirements file installation" src="https://github.com/user-attachments/assets/7e5edffb-4ddc-41df-abe8-b77e88162f61" /> |
| Console with virtual environment activated for user | <img width="598" height="309" alt="Terminal console showing activated virtual environment for user interaction" src="https://github.com/user-attachments/assets/c2acd251-88cb-4285-bd31-10c7c463051a" /> |
| Program execution with requirements file installation | <img width="1347" height="596" alt="Program running with automatic requirements file installation process" src="https://github.com/user-attachments/assets/f7e995e2-ff1c-4daf-bc73-9ee5a5430597" /> |
| User terminal session maintained after setup | <img width="566" height="257" alt="User terminal session preserved and ready for continued interaction" src="https://github.com/user-attachments/assets/bc28f7fa-3024-4461-ad58-6462c871fdd6" /> |

## Important Notes

- The `requirements.txt` file must contain the dependencies **before** running InitVenv
- The program will not understand requirements once the virtual environment is created
- Currently supports Windows systems only

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

See the [Release Notes](https://github.com/Dev2Forge/Init-Venv/releases) for detailed development history and changelog.

## License

This project is licensed under the GPL-3.0 License - see the [LICENSE](LICENSE) file for details.

## Links

- [Download from SourceForge](https://sourceforge.net/projects/init-venv/)
- [GitHub Releases](https://github.com/Dev2Forge/Init-Venv/releases)
- [Issues](https://github.com/Dev2Forge/Init-Venv/issues)
- [Pull Requests](https://github.com/Dev2Forge/Init-Venv/pulls)

## Contributors

<table>
  <tr>
    <td align="center"><a href="https://github.com/usuario"><img src="https://avatars.githubusercontent.com/tutosrive?v=4?s=100" width="100px;" alt=""/><br /><sub><b>tutosrive</b></sub></a><br /><a href="https://github.com/Dev2Forge/Init-Venv/commits?author=tutosrive" title="Code">💻</a></td>
  </tr>
</table>

---

⭐ If you find this tool useful, please consider giving it a star!
