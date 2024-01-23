using Microsoft.AspNetCore.OData; // AddOData extension method
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Packt.Shared; // AddNorthwindContext extension method

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddNorthwindContext();
builder.Services.AddControllers()
    .AddOData(options => options
    // register OData models
    .AddRouteComponents(routePrefix: "catalog", model: GetEdmModelForCatalog())
    .AddRouteComponents(routePrefix: "ordersystem", model: GetEdmModelForOrderSystem())
    // enable query options
    .Select() // enable $select for projection
    .Expand() // enable $expand to navigate to related entities
    .Filter() // enable $filter
    .OrderBy() // enable $orderby
    .SetMaxTop(100) // enable $top
    .Count() // enable $count
  );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



IEdmModel GetEdmModelForCatalog()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Category>("Categories");
    builder.EntitySet<Product>("Products");
    builder.EntitySet<Supplier>("Suppliers");
    return builder.GetEdmModel();
}
 IEdmModel GetEdmModelForOrderSystem()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Customer>("Customers");
    builder.EntitySet<Order>("Orders");
    builder.EntitySet<Employee>("Employees");
    builder.EntitySet<Product>("Products");
    builder.EntitySet<Shipper>("Shippers");
    return builder.GetEdmModel();
}