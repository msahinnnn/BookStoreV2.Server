using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.AutoFac;
using Business.Mapping.AutoMapper;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Business.Mapping;
using Autofac.Core;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Security.Encryption;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        //builder.WithOrigins("http://localhost:7079").AllowAnyHeader().AllowAnyMethod();
    });
});

//builder.Services.AddSingleton<IUserService, UserService>();
//builder.Services.AddSingleton<IUserDal, EfUserDal>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutoFacBusinessModule()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(AuthorProfile));
builder.Services.AddAutoMapper(typeof(BookProfile));
builder.Services.AddAutoMapper(typeof(PublisherProfile));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretkeymysecretkey")),
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
