using Ikk.Claims.Common;
using IKK.Claims.Application.Interfaces.Contexts;
using IKK.Claims.Application.Interfaces.FacadPatterns;
using IKK.Claims.Application.Interfaces.JwtAuthentication;
using IKK.Claims.Application.Services.Login;
using IKK.Claims.Application.Services.Users.FacadPatterns;
using IKK.Claims.Persistance.Contexts;
using IKK.Claims.Presentation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ClaimDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("lockalConnectionString")));
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager());
builder.Services.AddScoped<IClaimDbContext, ClaimDbContext>();
builder.Services.AddScoped<IUsersFacad, FacadUsers>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.Run();
