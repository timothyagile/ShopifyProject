# ShopifyProject

# Tải .NET từ trang chủ của Microsoft
 
# SQL Server on Docker
- Tải docker Desktop và Azure Data Studio
- Chạy từng lệnh bên dưới
```
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=123Phucthinh@" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```
- Running docker container trong docker desktop
- Mở Azure studio và tạo connection với những thông tin bên dưới
Server: localhost - SA - 123Phucthinh@

# Tạo project ASP.NET MVC trên VSCode
``` 
dotnet new mvc -n TenDuAnCuaBan
```

# Connect database
appsettings.json
``` json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost, 1433;Database=QLBanVaLi;User Id=SA;Password=123Phucthinh@;TrustServerCertificate=True;Encrypt=True"
  }
```
Program.cs
``` C#
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

# Entity framework
- Tải các package cần thiết
terminal vscode
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
- Chạy lệnh sau trong VSCode để tạo các entity tương ứng với database
```
dotnet ef dbcontext scaffold "Server=localhost,1433;Database=QLBanVaLi;User Id=SA;Password=123Phucthinh@;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context ApplicationDbContext --no-build
```

- Sử dụng lệnh tự tạo code CRUD trong Razor
- Đầu tiên, tải codegenerator:
``` dotnet tool install --global dotnet-aspnet-codegenerator ```
- Tiếp theo, sử dụng lệnh sau:
``` dotnet aspnet-codegenerator controller -name ProductsController -m Product -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries ```
Trong đó:

-name ProductsController: Tên của controller sẽ được tạo.
 
-m Product: Model mà controller này sử dụng.  

-dc ApplicationDbContext: DbContext mà bạn đang sử dụng.  

--relativeFolderPath Controllers: Thư mục nơi controller sẽ được tạo.  

--useDefaultLayout: Sử dụng layout mặc định cho views.  

--referenceScriptLibraries: Tham chiếu các thư viện script cần thiết.  



