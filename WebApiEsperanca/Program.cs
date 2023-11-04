using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiEsperanca.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication
                (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "dose",
                        ValidAudience = "dose",
                        IssuerSigningKey = new SymmetricSecurityKey
                      (Encoding.UTF8.GetBytes("c013239a-5e89-4749-b0bb-07fe4d21710d"))
                    };
                });
builder.Services.AddAuthorization();

builder.Services.AddDbContext<Context>(x => x.UseSqlServer("Server=DESKTOP-8D92RS3\\SQLEXPRESS;Database=bancoDoseEsperanca;User Id=teste;Password=teste;"));

var app = builder.Build();

app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
