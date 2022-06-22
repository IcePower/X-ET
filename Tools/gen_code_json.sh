#!/bin/zsh
WORKSPACE=..

GEN_CLIENT=${WORKSPACE}/Tools/Luban.ClientServer/Luban.ClientServer.dll
CONF_ROOT=${WORKSPACE}/Excel

echo ======================= Server ==========================
/usr/local/share/dotnet/dotnet ${GEN_CLIENT} --template_search_path CustomTemplate -j cfg --\
 -d ${CONF_ROOT}/Defines/__root__.xml \
 --input_data_dir ${CONF_ROOT}/Datas \
 --output_code_dir ${WORKSPACE}/Server/Model/Generate/Config \
 --output_data_dir ${WORKSPACE}/Config \
 --gen_types code_cs_bin,data_bin \
 -s server 

echo ======================= Client ==========================
/usr/local/share/dotnet/dotnet ${GEN_CLIENT} --template_search_path CustomTemplate -j cfg --\
 -d ${CONF_ROOT}/Defines/__root__.xml \
 --input_data_dir ${CONF_ROOT}/Datas \
 --output_code_dir ${WORKSPACE}/Unity/Codes/Model/Generate/Config \
 --output_data_dir ${WORKSPACE}/Unity/Assets/Bundles/Config \
 --gen_types code_cs_bin,data_bin \
 -s client
 
 echo ======================= JsonForView ==========================
 /usr/local/share/dotnet/dotnet ${GEN_CLIENT} -j cfg --\
  -d ${CONF_ROOT}/Defines/__root__.xml \
  --input_data_dir ${CONF_ROOT}/Datas \
  --output_data_dir ${CONF_ROOT}/Output_Json/Server \
  --gen_types data_json \
  -s server 
 
 /usr/local/share/dotnet/dotnet ${GEN_CLIENT} -j cfg --\
  -d ${CONF_ROOT}/Defines/__root__.xml \
  --input_data_dir ${CONF_ROOT}/Datas \
  --output_data_dir ${CONF_ROOT}/Output_Json/Client \
  --gen_types data_json \
  -s client