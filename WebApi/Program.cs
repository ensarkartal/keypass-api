using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi.Business.Jwt;
using WebApi.Core.Tenant.Abstract;
using WebApi.Core.Tenant.Cocnrete;
using WebApi.Domain.Abstract.App;
using WebApi.Domain.Abstract.IDentity;
using WebApi.Domain.Concrete.App.MongoDb.Operations;
using WebApi.Domain.Concrete.Identity.Mongo.Operations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{

    option.SwaggerDoc("v1", new OpenApiInfo { Title = "KeyPass API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
        ValidAudience = builder.Configuration["TokenOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecurityKey"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("WebApi"));
});


builder.Services.AddScoped<ITenantService, DummyTenantManager>();



//builder.Services.AddScoped<ITenantService, HttpTenantManager>();
builder.Services.AddScoped<IAppUserDal, MongoAppUserDal>();

builder.Services.AddScoped<IKeyGroupDal, MongoKeyGroupDal>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();





builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});


var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json",
            "KeyPass API v1");
        options.DefaultModelsExpandDepth(-1);
    });
    app.UseReDoc(c =>
    {
        c.DocumentTitle = "REDOC API Documentation";
        c.SpecUrl = "/swagger/v1/swagger.json";

    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


//app.UseMiddleware<JwtMiddleware>();
//app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
