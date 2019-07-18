# Debuggable Windows Service Template Project

Source code for Code Project article [Debuggable Windows Service Template Project with C#](https://www.codeproject.com/Articles/5162593/Debuggable-Windows-Service-Template-Project-with-C)

### Features
Sample project has the following features;

- It runs as a console application in debug mode and as a regular windows service in release mode.
- Displays log mesages on the console with different text colors depending on the log type.
- Windows service related operations and actual background task processing operations are separated so the actual service operations can be unit tested easily.
- Service can be installed and uninstalled using InstallUtil.exe. But you do not need to install it in order to test and debug.
