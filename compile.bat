@echo off
REM Script de compilation du helper C# Media Info Getter

echo Compilation de MediaInfoGetter.exe...
echo.

REM Vérifier si dotnet est installé
where dotnet >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo ERREUR: .NET SDK n'est pas installe.
    echo.
    echo Telechargez et installez .NET 6.0 SDK depuis:
    echo https://dotnet.microsoft.com/download/dotnet/6.0
    echo.
    pause
    exit /b 1
)

REM Compiler le projet
dotnet publish MediaInfoGetter.csproj -c Release -o .

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ============================================
    echo Compilation reussie!
    echo L'executable MediaInfoGetter.exe est pret.
    echo ============================================
    echo.
) else (
    echo.
    echo ============================================
    echo ERREUR lors de la compilation
    echo ============================================
    echo.
)

pause
