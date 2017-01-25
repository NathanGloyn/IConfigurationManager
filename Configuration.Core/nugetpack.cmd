:Uses nuget.exe 3.5 in PATH. Use "VS2015" to compile all configurations before packing.
:Version and other important properties obtained from AssemblyInfo.cs
:Update AssemblyInfo and releaseNotes here with each release.
@echo off
:del /s obj\*.cs
nuget pack Configuration.Core.csproj -verbosity detailed -o pkg -symbols -properties configuration=Release-net40;releaseNotes="Added SymbolSource for targeting server for debug symbols"