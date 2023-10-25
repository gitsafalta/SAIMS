using System.Globalization;
using Microsoft.AspNetCore.Localization;
using minAPIFile;
using SAIMS.Infrastructure;
using SAIMS.Application;
using SAIMS.Application.ExceptionMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SAIMS.Application.JwtMiddleware;
using SAIMS.Application.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*DI*/
builder.Services.AddApplication();
builder.Services.AddDatabase();
builder.Services.AddRepositoriesWithInfrastructure();
builder.Services.AddServices();

/*Localization & Globalization*/
var supportedCultures = new List <CultureInfo> {
        new CultureInfo("fr-FR"),
        new CultureInfo("en-US")
    };
builder.Services.Configure <RequestLocalizationOptions> (options => {    
    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", builder =>
                      {
                          builder.AllowAnyOrigin();
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                      });
});

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

/*Minimal Api - endpoints*/
TodoEndpoints.Map(app);

/*JWT*/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<JwtMiddleware>();
app.UseRequestLocalization();
app.UseRouting();

app.UseCors("CORS");

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
