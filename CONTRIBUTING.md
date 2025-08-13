# Contributing to InitVenv ⚙️

<div align="center">
  <img width="512" height="512" alt="InitVenv-logo" src="https://github.com/user-attachments/assets/ba2d58d0-75bc-4d7d-9a13-9969d7de3993" />
</div>

Thank you for considering contributing to **InitVenv**! We welcome your help to improve our cross-platform automation tool for Python virtual environment management. Please follow these guidelines to help us maintain a high-quality project.

## How to Contribute

### 1. Reporting Issues
- Use the *GitHub Issues* tab to report bugs, request features, or ask questions.
- Please provide as much detail as possible, including:
  - Your operating system (Windows version, future Linux/macOS versions)
  - Python version installed
  - Steps to reproduce the issue
  - Expected vs. actual behavior
  - Screenshots if applicable

### 2. Suggesting Enhancements
- Open an issue and describe your idea.
- Explain how it benefits users of **InitVenv**.
- Consider cross-platform compatibility (Windows, Linux, macOS roadmap).
- Provide use cases and examples.

### 3. Submitting Pull Requests
- Fork the repository and create your branch from `main`.
- Follow the style and conventions used in the codebase (primarily *C#/.NET*).
- Write clear, concise commit messages.
- Test your changes thoroughly before submitting:
  - Test with different Python versions
  - Test with various `requirements.txt` configurations
  - Test both File Explorer and command-line usage methods
- Reference related issues in your PR description.
- Ensure your changes don't break existing functionality.

### 4. Coding Standards
- Use .NET compatible code following C# best practices.
- Follow established naming conventions and code structure.
- Add comprehensive error handling and validation.
- Include XML documentation comments for public methods and classes.
- Ensure cross-platform compatibility considerations for future releases.

### 5. Testing Guidelines
- Test the installer functionality:
  - PATH environment variable updates
  - Batch file generation and execution
  - Architecture-specific executable handling
- Test core functionality:
  - Virtual environment creation
  - Requirements installation from `requirements.txt`
  - Directory path handling (absolute and relative)
  - Error scenarios (missing Python, invalid paths, etc.)

### 6. Documentation
- Update README.md if your changes affect usage instructions.
- Document new features, command-line options, or configuration changes.
- Update release notes for significant changes.
- Ensure all public APIs are properly documented.

### 7. Platform Support
- **Current**: Windows-only implementation
- **Future**: Linux and macOS support planned
- When contributing, consider how changes might affect future cross-platform implementation.
- Avoid Windows-specific code where possible to ease future porting.

### 8. Code Review
- All PRs are subject to review by the Dev2Forge team.
- Be open to feedback and willing to make improvements.
- Respond promptly to review comments.
- Ensure CI/CD checks pass before requesting review.

## Development Setup

1. Clone the repository
2. Ensure you have the required .NET SDK installed
3. Build the project locally
4. Test with various Python environments and project configurations

## Areas for Contribution

- **Cross-platform support**: Help implement Linux and macOS compatibility
- **Error handling**: Improve user experience with better error messages
- **Performance**: Optimize virtual environment creation and package installation
- **Testing**: Add automated testing for various scenarios
- **Documentation**: Improve user guides and developer documentation

## Code of Conduct

Please be respectful and constructive in all interactions. Discrimination, harassment, or inappropriate behavior will not be tolerated. We strive to maintain an inclusive and welcoming community for all contributors.

## License

By contributing, you agree that your work will be released under the project's license (**GPL-3.0**).

## Getting Help

- Check existing [Issues](https://github.com/Dev2Forge/Init-Venv/issues) for similar questions
- Join discussions in Pull Requests
- Contact [@tutosrive](https://github.com/tutosrive) for project-specific questions

---

Thank you for helping make InitVenv better! 🚀
