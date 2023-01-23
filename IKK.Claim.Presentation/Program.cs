using IKK.Claim.Application.Interfaces.Contexts;
using IKK.Claim.Application.Interfaces.FacadPatterns;
using IKK.Claim.Application.Services.Users.FacadPatterns;
using IKK.Claim.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ClaimDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("lockalConnectionString")));
builder.Services.AddSwaggerGen();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
