using System.Reflection;
using System.Text;
using Application.Authentication;
using Application.Behaviours;
using Application.Common.BaseModels;
using Application.Common.Interfaces;
using Application.Games.Models.Responses;
using Domain.Entities;
using FluentValidation;
using Interface.Games.Hubs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance.Data;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "AceTracker API", Version = "v1" });
    options.AddSignalRSwaggerGen();
});

builder.Services.AddSignalR();

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

builder.Services.AddScoped<ICreationResult<CreateGameResponse>, CreationResult<CreateGameResponse>>();


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
    options.UseSqlServer(builder.Configuration["AceTracker:ConnectionString"], b => b.MigrationsAssembly("Persistance"));
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssembly(typeof(CreationResult<>).Assembly);
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

