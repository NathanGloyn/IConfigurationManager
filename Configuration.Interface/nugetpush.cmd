@echo off

DIR pkg\*.nupkg /B /O:-D | FOR /F %%I IN ('findstr /v /i "\.symbols.nupkg$"') DO ^
nuget push pkg\%%I %apikey% -Source https://www.nuget.org/api/v2/package ^
& exit /B
