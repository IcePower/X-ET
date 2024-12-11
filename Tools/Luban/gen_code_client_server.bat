@echo off
set WORKSPACE=..\..

set GEN_CLIENT=Luban\Luban.exe
set CONF_ROOT=%WORKSPACE%\Unity\Assets\Config\Excel
set OUTPUT_CODE_DIR=%WORKSPACE%\Unity\Assets\Scripts\Model\Generate
set OUTPUT_DATA_DIR=%WORKSPACE%\Config\Excel
set OUTPUT_JSON_DIR=%WORKSPACE%\Config\Json
set CONFIG_FOLDER=%1

:: ClientServer
echo =====================================================================================================
echo ======================= ClientServer GameConfig ==========================
%GEN_CLIENT% ^
 --customTemplateDir CustomTemplate ^
 --conf %CONF_ROOT%\Defines\__luban__.conf ^
 -x outputCodeDir=%OUTPUT_CODE_DIR%\ClientServer\Config ^
 -x bin.outputDataDir=%OUTPUT_DATA_DIR%\cs\GameConfig ^
 -x json.outputDataDir=%OUTPUT_JSON_DIR%\cs\GameConfig ^
 -d json ^
 -d bin ^
 -c cs-bin ^
 -t all

if %errorlevel% equ 1 (
    exit /b 1
)

echo =====================================================================================================
echo ======================= ClientServer StartConfig %CONFIG_FOLDER% ==========================
%GEN_CLIENT% ^
 --customTemplateDir CustomTemplate ^
 --conf %CONF_ROOT%\Datas\StartConfig\%CONFIG_FOLDER%\__luban__.conf ^
 -x outputCodeDir=%OUTPUT_CODE_DIR%\ClientServer\StartConfig ^
 -x bin.outputDataDir=%OUTPUT_DATA_DIR%\cs\StartConfig\%CONFIG_FOLDER% ^
 -x json.outputDataDir=%OUTPUT_JSON_DIR%\cs\StartConfig\%CONFIG_FOLDER% ^
 -d json ^
 -d bin ^
 -c cs-bin ^
 -t all
