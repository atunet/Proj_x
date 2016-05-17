#!/bin/sh


for file in ./*.proto
do
	echo convert proto to lua file: $file ...
	protoc --lua_out=../LuaScripts/Protos/ $file

	echo convert proto to binary file: $file ...
	protoc -o ../LuaScripts/Protos/${file/proto/pb} $file 
done
