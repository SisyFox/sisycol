#!/bin/sh

CORE_COUNT=$(grep -c ^processor /proc/cpuinfo)

echo "detected ${CORE_COUNT} cores"

git submodule update --init

cd thirdParty
mkdir -p cache_flatbuffers && cd cache_flatbuffers

cmake ../flatbuffers && make flatc -j${CORE_COUNT}

cd ../../src
mkdir -p cpp && cd cpp

../../thirdParty/cache_flatbuffers/flatc --cpp ../../sisycol.fbs

cd .. && mkdir -p js && cd js

../../thirdParty/cache_flatbuffers/flatc --js ../../sisycol.fbs

cd .. && mkdir -p csharp && cd csharp

../../thirdParty/cache_flatbuffers/flatc --csharp --gen-onefile ../../sisycol.fbs

cd ../..
