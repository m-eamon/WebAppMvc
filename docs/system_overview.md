### System Overview 

#### Architecture
![Architecture](./docs/imgs/architecture.png)

The system consists of an MVC web application which consumes services from two apis - product and shopping-cart.  The web application can list all products, show product details, add a product to the shopping cart and remove a product from the cart.

The product and shopping-cart apis are each connected to a separate MSSQL Server database.

The databases, apis and mvc web application all run in docker containers.