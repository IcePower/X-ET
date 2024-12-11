#!/bin/zsh
WORKSPACE=../..

GEN_CLIENT=Luban/Luban.dll
CONF_ROOT=${WORKSPACE}/Unity/Assets/Config/Excel
OUTPUT_CODE_DIR=${WORKSPACE}/Unity/Assets/Scripts/Model/Generate
OUTPUT_DATA_DIR=${WORKSPACE}/Config/Excel
OUTPUT_JSON_DIR=${WORKSPACE}/Config/Json
  
echo ======================= Client ==========================
/usr/local/share/dotnet/dotnet ${GEN_CLIENT} \
 --customTemplateDir CustomTemplate \
 --conf $CONF_ROOT/Defines/__luban__.conf \
 -x outputCodeDir=${OUTPUT_CODE_DIR}/Client/Config \
 -x bin.outputDataDir=${OUTPUT_DATA_DIR}/c/GameConfig \
 -x json.outputDataDir=${OUTPUT_JSON_DIR}/c/GameConfig \
 --excludeTag s \
 -d json \
 -d bin \
 -c cs-bin \
 -t client
  
if [ $? -eq 1 ]; then
    exit 1
fi