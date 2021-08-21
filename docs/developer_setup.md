# Developer Setup


### Requirments
* .Net Framework V5
* dotnet cli
* Visual Studio Code


### Create 
This project was created using the following commands

```
dotnet new mvc - o WebAppMvc
```

### Packages to add
```shell
dotnet add package Newtonsoft.Json

```
Trust the HTTP development certificate (Linux)

```
dotnet dev-certs https    
```

### Api Calls
A <strong>ProductController</strong> was added to handle ProductApi calls. The results are passed to the Product Details and Index Views.   
A <strong>CartItemController</strong> was added to handle ProductApi calls. The results are passed to the CartItem Index View.   

### Models
<strong>ProductModel</strong> and <strong>CartItem</strong> models added to map the JSON results from the ProductApi and ShoppingCartApi calls.  The JSON passed is the same for each api call.

### Verify
Run the application and verify that you can see the home page.

```
dotnet run
```
Go to where the app has been started, by default its usually https://localhost:5001

### ProductApi & Shopping Cart Api
The README.md docs for each of these projects describe the setup.

### Docker Containers
There is one docker containers for this project.

#### App Docker Container
The <strong>dockerfile</strong> file will build and run the WebApp application in a docker container.  


### Docker-Compose
This <strong>docker-compose.yml</strong> file will define and run all containers in this project:

* products-api
* products-db
* shoppingcart-api
* shoppingcart-db
* webappmvc

```shell
docker-compose up --build
```

### Github repository
https://github.com/m-eamon/WebAppMvc.git

