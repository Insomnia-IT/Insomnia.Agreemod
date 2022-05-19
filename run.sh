#!/bin/bash

NAME=nt_load

docker rm -f $NAME
docker build --no-cache -t $NAME .
docker run -p 4000:80 -it --name $NAME $NAME

