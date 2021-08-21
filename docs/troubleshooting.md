# Troubleshooting


### DBCreate
There was an issue writing SQL scripts to create the ProductsDB and ShoppingCartDB because it looked like the databases weren't ready when the database containers were spun up to allow the scripts to be run.  This was resolved in both APIs in the startup.cs with a DBCreate call.  This creates the database and associated schema (including required tables.)

```csharp

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CartContext cdb)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingCartApi v1"));
        }

        // create the ShoppingCartDB database
        cdb.Database.EnsureCreated();
```


### HTTPS development certificate   
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

### Services
The API calls in the controllers should be moved to a ProductService and a ShoppingCartService.  However, I couldn't get this to work.  So the APIs calls violate the DRY principle.  This should be corrected.
 

### BaseAddress
There is an issue with the client.BaseAddress depending on how the application is run.  If the MVC app is run in a container as part of the full project, the URI is <strong>"https://products-api:8085"</strong>.  If the MVC is run from the command line, the URI is <strong>"https://localhost:5006"</strong>.  This should be added to a property so the URI can be configured easily.

### Port 1433
There was a port conflict with the shoppingcart-db when spinning up all containers.  Changed port to 1434 so it didn't conflict with products-db.

### Views
The Presentation layer (Views) needs work. 

