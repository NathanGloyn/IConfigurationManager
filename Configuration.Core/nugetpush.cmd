:Using nuget.exe 3.5 in PATH, pushes latest nupkg in current directory to nuget gallery.
:You need to be registered with nuget and an owner of this package and 
:'nuget setApiKey your-nuget-api-key' before calling.
:Symbols are also pushed to SymbolSource.
@echo off

:Push latest *.nupkg (excluding *.symbols.nupkg as is done automatic).  
:Assumes latest built is proper version from AssemblyInfo.cs
DIR pkg\*.nupkg /B /O:-D | FOR /F %%I IN ('findstr /v /i "\.symbols.nupkg$"') DO ^
nuget push pkg\%%I -Source https://www.nuget.org/api/v2/package -SymbolSource ^
& exit /B

:The above is impossible to understand so let me explain ...
:1) 'DIR pkg\*.nupkg /B /O:-D' lists out all *.nupkg files including *.symbols.nupkg without header or summary lines.
:	It is sorted by date descending so the newest file is listed first
:2) The output is piped to the command inside the FOR .. the specifically the findstr command.
:3) 'findstr /v /i "\.symbols.nupkg$"' will display each line that does not end with .symbols.nupkg
:4) So we are left with just nupkg files, no symbol.nupkg files being passed to DO command, newest first.
:5) The carret (^) is a line continuation.
:6) nuget is called for the latest nupkg file.
:	(You must register with nuget to get an apikey.  Set from cmd prompt with 'nuget setApiKey'.)
:7) Then exit is called which quits the current shell.  The pipe started a new shell so that is exited, not the whole script or cmd window.
:8) Since we exited after the first call to DO nuget .. only one (the latest) nupkg file is pushed.
:9) Control is returned to calling shell and eof is reached.

