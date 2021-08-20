# WebAppMvc

* Project setup 
    * [System Overview](./docs/system_overview.md)
    * [Developer Setup](./docs/developer_setup.md)
    * [Trouble Shooting](./docs/troubleshooting.md)
   
### Developer Setup
Refer to docs for setup of Api and MVC

Add Models - Product, CartItem 

Add Controller - Product, CartItem

Add View -  Product, CartItem

Add Docker 
Change localhost to docker container names in api calls

#### Docker Containers
Containers Docker compose - One compose to rule them all

### packages to add
```shell
dotnet add package Newtonsoft.Json

```

### Github repository
https://github.com/m-eamon/WebAppMvc.git


### Troubleshoot

DBCreate - Fix

####   
I think there is an issue with the HTTPS development certificate of localhost. When the product or shopping cart api is called from the mvc, the following error is generated:

```
 HttpRequestException: The SSL connection could not be established, see inner exception.

```

This issue is resolved by forcing certificate trust in the api calls.  This code should be removed for properly trusted certificates.  

```csharp
 public IActionResult Index()
{
            
    var httpClientHandler = new HttpClientHandler();
    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
    {
                return true;
    };

```

Service Issue - Could not work - Refactor
 


This issue
                // this should be in a separate file
                client.BaseAddress = new Uri("https://products-api:8085");

                //client.BaseAddress = new Uri("https://localhost:5006");


Port 1433 issue for db connection
Routing in MVC
View - Presentation Layer (View layer) - Much work