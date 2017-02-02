:Uses nuget.exe 3.5 in PATH. Use "VS2015" to "batch build" all configurations before packing.
:Version and other important properties obtained from AssemblyInfo.cs
:Update AssemblyInfo and releaseNotes here with each release.
@echo off
:del /s obj\*.cs
nuget pack ..\Configuration.Core\Configuration.Core.csproj -verbosity detailed -o pkg -symbols -properties configuration=Release-net40;releaseNotes="Symbol push bug fix"
nuget pack ..\Configuration.Interface\Configuration.Interface.csproj -verbosity detailed -o pkg -symbols -properties configuration=Release-net40;releaseNotes="Symbol push bug fix"