#!/bin/sh


for file in ./*.proto
do
	echo convert proto to lua file: $file ...
	protoc --lua_out=../LuaScripts/Proto/ $file

	echo convert proto to binary file: $file ...
	protoc -o ../LuaScripts/Proto/${file/proto/pb} $file 
done
