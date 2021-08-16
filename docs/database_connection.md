# Database connection

### Configuration
Ensure database connection is setup with the correct context and Docker connection in the <strong>startup.cs</strong> file. 

```csharp
 public void ConfigureServices(IServiceCollection services)
 {

    services.AddControllers();

    //SQL Server - Docker image
    services.AddDbContext<ProductContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("LocalDockerConnection")));        
            
    ervices.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductApi", Version = "v1" });
    });
}

```

The LocalDocker connection is configured in the <strong>appsettings.json</strong> file.

```json
{
  "ConnectionStrings": {
    "LocalDockerConnection": "Server=products-db,1433;Database=ProductsDB;User ID=sa;Password=Passw0rd;Trusted_Connection=False;MultipleActiveResultSets=true"
    }
}

```
The ProductDB database is created (if it doesn't already existed) by the pb.Database.EnsureCreated() method in the <strong>startup.cs</strong> file.  The ProductContext is passed the Configure method.

```csharp

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProductContext pb)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductApi v1"));
            }

            // create the ProductsDB database
            pb.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
```