# Scaffold Controller

### Product & ProductContext Models
These Product and ProdctContext classes is used with Entity Framework Core (EF Core) to work with the ProductDB database.

```csharp
namespace ProductApi.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Price {get; set;}

        public string Retailer {get; set;}
    }
}

using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
```

### Add NuGet packages
```shell
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

```

### Export the scaffold tool path
```shell
export PATH=$HOME/.dotnet/tools:$PATH
```

### Scaffold Product Controller
```shell
dotnet aspnet-codegenerator controller -name ProductItemsController -async -api -m ProductItem -dc ProductContext -outDir Controllers

```

### Verify
ProductsController for CRUD operations will now be available.
