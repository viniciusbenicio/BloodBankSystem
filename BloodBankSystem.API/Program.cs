using BloodBankSystem.API.ExceptionHandler;
using BloodBankSystem.Application;
using BloodBankSystem.Infrastructure;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
       .AddInfraescrture(builder.Configuration)
       .AddApplication();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(op =>
{
    op.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BloodBankSystem API",
        Description = "Uma API .NET Core para gerenciar banco de doação de Sangue",
        TermsOfService = new Uri("https://github.com/viniciusbenicio/BloodBankSystem"),
        Contact = new OpenApiContact
        {
            Name = "Vinicius Benicio de Santana",
            Url = new Uri("https://linkedin.com/in/viniciusbenicio")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://github.com/viniciusbenicio/BloodBankSystem")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    op.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
