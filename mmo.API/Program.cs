using mmo.Application;
using mmo.Application.Exceptions;
using mmo.Infrastructure;
using mmo.Persistence;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting Web Host");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());
    
    var services = builder.Services;
    var configuration = builder.Configuration;
    // Add services to the container.

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddTransient<UseExceptionMiddleware>();
    services.AddApplicationServices();
    services.AddPersistenceServices(configuration["DbConnection:SQLServer:ConnectionString"]);
    services.AddInfrastructureServices();

    var app = builder.Build();
    
    app.UseSerilogRequestLogging(options =>
    {
        options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
    });

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.Use(async (context, task) =>
    {
        Console.WriteLine(context.Response.StatusCode);
        await task.Invoke();
        Console.WriteLine(context.Response.StatusCode);
    });
    app.UseHttpsRedirection();

    app.UseMiddleware<UseExceptionMiddleware>();

    app.UseStaticFiles();

    app.UseAuthorization();

    app.UseRequestLocalization();
    
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

return 0;