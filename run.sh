#!/bin/bash

NAME=agreemod

docker build --no-cache -t $NAME .
docker rm -f $NAME
docker run -d -p 5500:80 --restart=always --name $NAME $NAME

