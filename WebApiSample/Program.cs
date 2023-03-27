using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiSample;
using WebApiSample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --JWT Authentication
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:5067",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes("superSecretKey@345"))
        };
    });
// --


// -- CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DEV_CORS", builder =>
    {
        builder.AllowAnyOrigin()
                //.WithOrigins("https://localhost:3000", "http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();

    });
});
// --

builder.Services.AddDbContext<ServerDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<User>()
    .AddEntityFrameworkStores<ServerDb>();


builder.Services.AddSingleton(new MapperConfiguration(conf =>
{
    conf.AddProfile(new MappingProfile());
}).CreateMapper());




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddIdentity<User, IdentityRole>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DEV_CORS");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
