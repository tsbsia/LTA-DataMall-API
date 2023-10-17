using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Serilog;
using TsbSia.LtaDataMallApi.Options;
using TsbSia.LtaDataMallApi.Services;

var builder = WebApplication.CreateBuilder(args);

//Configure Logger
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services), writeToProviders: false);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "LTA DataMall API",
        Description = "An ASP.NET Web API for querying transport-related datasets from Singapore LTA DataMall.",
        Contact = new OpenApiContact
        {
            Name = "LTA DataMall API",
            Url = new Uri("https://github.com/tsbsia/LTA-DataMall-API"),
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://github.com/tsbsia/LTA-DataMall-API/blob/master/LICENSE"),
        }
    });
});

builder.Services.Configure<LtaDataServiceOptions>(builder.Configuration.GetSection(LtaDataServiceOptions.SectionName));

builder.Services.AddScoped(typeof(ILtaDataService), typeof(LtaDataService));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
