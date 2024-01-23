using Kestra.CareStationDeviceUsageApi;
using Kestra.KestraDwDb;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<KestraDbOptions>(builder.Configuration.GetSection(AppConstants.KEY));
builder.Services.AddKestraDBContext(builder.Configuration);
//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddOData(options => options
    // register OData models
    .AddRouteComponents(routePrefix: "CareStationDeviceUsage", model: GetEdmModelForCareStationDeviceUsage())
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



IEdmModel GetEdmModelForCareStationDeviceUsage()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Invoice>("CareStationDeviceUsage");
    return builder.GetEdmModel();
}