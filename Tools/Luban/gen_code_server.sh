#!/bin/zsh
WORKSPACE=../..

GEN_CLIENT=Luban/Luban.dll
CONF_ROOT=${WORKSPACE}/Unity/Assets/Config/Excel
OUTPUT_CODE_DIR=${WORKSPACE}/Unity/Assets/Scripts/Model/Generate
OUTPUT_DATA_DIR=${WORKSPACE}/Config/Excel
OUTPUT_JSON_DIR=${WORKSPACE}/Config/Json
CONFIG_FOLDER=$1
  
#Server
echo =====================================================================================================
echo ======================= Server GameConfig ==========================
/usr/local/share/dotnet/dotnet ${GEN_CLIENT} \
 --customTemplateDir CustomTemplate \
 --conf $CONF_ROOT/Defines/__luban__.conf \
 -x outputCodeDir=${OUTPUT_CODE_DIR}/Server/Config \
 -x bin.outputDataDir=${OUTPUT_DATA_DIR}/s/GameConfig \
 -x json.outputDataDir=${OUTPUT_JSON_DIR}/s/GameConfig \
 --excludeTag c \
 -d json \
 -d bin \
 -c cs-bin \
 -t server
  
if [ $? -eq 1 ]; then
    exit 1
fi

echo =====================================================================================================
echo ======================= Server StartConfig ${CONFIG_FOLDER} ==========================
/usr/local/share/dotnet/dotnet ${GEN_CLIENT} \
 --customTemplateDir CustomTemplate \
 --conf ${CONF_ROOT}/Datas/StartConfig/${CONFIG_FOLDER}/__luban__.conf \
 -x outputCodeDir=${OUTPUT_CODE_DIR}/Server/StartConfig \
 -x bin.outputDataDir=${OUTPUT_DATA_DIR}/s/StartConfig/${CONFIG_FOLDER} \
 -x json.outputDataDir=${OUTPUT_JSON_DIR}/s/StartConfig/${CONFIG_FOLDER} \
 --excludeTag c \
 -d json \
 -d bin \
 -c cs-bin \
 -t server