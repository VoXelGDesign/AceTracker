using Application.Games.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;
using AceTrackerServer.Data;
using Microsoft.EntityFrameworkCore;
using Application.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using MediatR;
using FluentValidation;
using Application.Behaviors;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "AceTracker API", Version = "v1" });
    options.AddSignalRSwaggerGen();
});

builder.Services.AddSignalR();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

AuthenticationSettings authenticationSettings = new AuthenticationSettings();
var issuer = builder.Configuration["Authentication:JwtIssuer"];
var key = builder.Configuration["Authentication:JwtKey"];

if (int.TryParse(builder.Configuration["Authentication:JwtExpireHours"], out var expires) 
    && issuer is not null 
    && key is not null)
{
    authenticationSettings = new AuthenticationSettings()
    {
        JwtExpireHours = expires,
        JwtIssuer = issuer,
        JwtKey = key
    };
}

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();


//Authentication
builder.Services.AddSingleton(authenticationSettings);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))

    };
});


builder.Services.AddDbContext<AceTrackerDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration["AceTracker:ConnectionString"], b => b.MigrationsAssembly("Infrastructure"));
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<GameHub>("signalrapi");

app.Run();



