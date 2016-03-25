#!/bin/sh


for file in ./*.proto
do
	echo convert proto to lua file: $file ...
	protoc --lua_out=../LuaLogic/protos/ $file

	echo convert proto to binary file: $file ...
	protoc -o ../LuaLogic/protos/${file/proto/pb} $file 
done
