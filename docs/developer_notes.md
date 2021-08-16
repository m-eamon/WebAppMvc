# Developer Notes

### Running application in containers
```shell
docker-compose up --build
```

To run in the background
```shell
docker-compose up --build -d
```

### Github repository
https://github.com/m-eamon/ProductApi.git

### Connecting to the application
The application runs on the port 5006.  To test the CRUD api calls:
https://localhost:5006/swagger/index.html


### Populating Products Table
```shell
docker exec products-db /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Passw0rd" -i "./populateProduct.sql"
```
