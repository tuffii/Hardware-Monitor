@echo off
setlocal

set "solutionPath=%~dp0..\src\hardwareMonitor.sln"

rem Проверка существования файла решения
if not exist "%solutionPath%" (
    echo Файл решения не найден: "%solutionPath%"
    exit /b 1
)

msbuild.exe "%solutionPath%" /t:Build /p:Configuration=Release

endlocal
