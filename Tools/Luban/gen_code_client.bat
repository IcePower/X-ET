@echo off

set WORKSPACE=..\..
set GEN_CLIENT=Luban\Luban.exe
set CONF_ROOT=%WORKSPACE%\Unity\Assets\Config\Excel
set OUTPUT_CODE_DIR=%WORKSPACE%\Unity\Assets\Scripts\Model\Generate
set OUTPUT_DATA_DIR=%WORKSPACE%\Config\Excel
set OUTPUT_JSON_DIR=%WORKSPACE%\Config\Json

echo ======================= Client ==========================
%GEN_CLIENT% ^
 --customTemplateDir CustomTemplate ^
 --conf %CONF_ROOT%\Defines\__luban__.conf ^
 -x outputCodeDir=%OUTPUT_CODE_DIR%\Client\Config ^
 -x bin.outputDataDir=%OUTPUT_DATA_DIR%\c\GameConfig ^
 -x json.outputDataDir=%OUTPUT_JSON_DIR%\c\GameConfig ^
 --excludeTag s ^
 -d json ^
 -d bin ^
 -c cs-bin ^
 -t client

if %errorlevel% equ 1 (
    exit /b 1
)
