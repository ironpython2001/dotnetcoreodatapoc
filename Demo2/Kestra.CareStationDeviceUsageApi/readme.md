##### To scaffold
* dotnet ef dbcontext scaffold "Server=localhost\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer  --no-onconfiguring --force  --context KestraDbContext -t Invoices

where 'Invoices' is the view name 


##### steps to run the application
1. dotnet build
2. dotnet run --launch-profile https
3. in browser https://localhost:7000/swagger/index.html


##### References
* [Getting Started with ASP.NET Core OData 8 - OData | Microsoft Learn](https://learn.microsoft.com/en-us/odata/webapi-8/getting-started?tabs=net60%2Cvisual-studio-2022%2Cvisual-studio)
* [Client-driven Paging in ASP.NET Core OData 8 - OData | Microsoft Learn](https://learn.microsoft.com/en-us/odata/webapi-8/fundamentals/client-driven-paging)
* In Invoice.cs we need to define the property [Key]
* [EntityType: EntitySet ‘[Entity Name]’ is based on type ‘[Entity Name]’ that has no keys defined](https://blog.taditdash.com/entitytype-entityset-entity-name-is-based-on-type-entity-name-that-has-no-keys-defined)
* [aletc1/examples-odata-azure-functions: Implementando OData en Azure Functions v2](https://github.com/aletc1/examples-odata-azure-functions)

curl -X 'GET' \
  'https://localhost:7000/CareStationDeviceUsage/CareStationDeviceUsage(%27QUICK-Stop%27)' \
  -H 'accept: */*'