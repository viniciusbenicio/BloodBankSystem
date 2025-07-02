using BloodBankSystem.API.ExceptionHandler;
using BloodBankSystem.Application;
using BloodBankSystem.Application.Job;
using BloodBankSystem.Core.Entities;
using BloodBankSystem.Infrastructure;
using Hangfire;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
       .AddInfraescrture(builder.Configuration)
       .AddApplication()
       .AddUnifOfWork()
       .AddServicesExternal()
       .AddExceptionHandler<ApiExceptionHandler>()
       .AddProblemDetails()
       .AddControllers();



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

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<NotificationTask>("job-send-notification", jb => jb.Execute(), "*/1 * * * *");


var smtp = new BloodBankSystem.Core.Entities.SmtpConfiguration();
app.Configuration.GetSection("Smtp").Bind(smtp);
Configuration.SMTP = smtp;


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
