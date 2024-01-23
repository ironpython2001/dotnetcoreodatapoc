using Kestra.KestraDwDb;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Kestra.CareStationDeviceUsageApi;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddKestraDBContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        var adminDbOptions = configuration.GetSection(AppConstants.KEY).Get<KestraDbOptions>();
        SqlConnectionStringBuilder builder = new();
        builder.ConnectionString = adminDbOptions!.ConnectionString;
        builder.MultipleActiveResultSets = true;
        //builder.ConnectTimeout = adminDbOptions.ConnectTimeout;
        var connectionString = builder.ConnectionString;
        services.AddDbContext<KestraDbContext>
        (options =>
        {
            options.UseSqlServer(connectionString);
            //// Log to console when executing EF Core commands.
            //options.LogTo(Console.WriteLine, new[]
            //{ 
            //    Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting
            //});
        },
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient
        );
        services.AddScoped<KestraDbContext, KestraDbContext>();
        //services.AddScoped<AppAdminDbContext>();
        return services;
    }
}