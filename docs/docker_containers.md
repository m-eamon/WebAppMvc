# Docker Containers
There are two docker containers for this project, one for the api app and one for the MSSQL database.

### App Docker Container
The <strong>dockerfile</strong> file will build and run the ProductApi application in a docker container.  

### DB Docker Container
The <strong>mssql/dockerfile</strong> will build and run the db in a docker container.  It pulls the latest sql server docker image.  

### Docker-Compose
This <strong>docker-compose.yml</strong> file will define and run both containers. To run:

```shell
docker-compose up --build
```