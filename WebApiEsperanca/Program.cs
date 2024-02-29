using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApiEsperanca.Application.Service;
using WebApiEsperanca.Controllers;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("c013239a-5e89-4749-b0bb-07fe4d21710d"))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddDbContext<Context>(x => x.UseSqlServer("workstation id = bancoDoseEsperanca.mssql.somee.com; packet size = 4096; user id = kauamartinsvar_SQLLogin_1; pwd = oz2i61ryfm; data source = bancoDoseEsperanca.mssql.somee.com; persist security info=False; initial catalog = bancoDoseEsperanca\r\n;"));
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Configuração dos WebSockets
app.UseWebSockets();

//app.Map("/", async context =>
//{
//    if (!context.WebSockets.IsWebSocketRequest)
//    {
//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//        return;
//    }

//    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
//    var cancellationToken = context.RequestAborted;

//    try
//    {
//        while (webSocket.State == WebSocketState.Open)
//        {
//            using (var scope = context.RequestServices.CreateScope())
//            {
//                var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

//                try
//                {
//                    var usuarios = dbContext.tabUsuario.ToList();

//                    var usuariosJson = JsonSerializer.Serialize(usuarios);

//                    await webSocket.SendAsync(Encoding.UTF8.GetBytes(usuariosJson), WebSocketMessageType.Text, true, cancellationToken);

//                    await Task.Delay(1000);
//                }
//                finally
//                {
//                    dbContext.Dispose();
//                }
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//    }
//    finally
//    {
//        if (webSocket.State == WebSocketState.Open)
//            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken);
//    }
//});

//await app.RunAsync();
app.Map("/", async context =>
{
    // Substitua o trecho do código que lida com a conexão WebSocket
    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
    var cancellationToken = context.RequestAborted;

    try
    {
        while (webSocket.State == WebSocketState.Open)
        {
            using (var scope = context.RequestServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

                try
                {
                    var buffer = new ArraySegment<byte>(new byte[25]);
                    WebSocketReceiveResult receivedResult;

                    do
                    {
                        receivedResult = await webSocket.ReceiveAsync(buffer, cancellationToken);

                        if (receivedResult.MessageType == WebSocketMessageType.Text)
                        {
                            var receivedMessage = Encoding.UTF8.GetString(buffer.Array, 0, receivedResult.Count);
                            var parsedMessage = JsonSerializer.Deserialize<Dictionary<string, string>>(receivedMessage);
                            if (parsedMessage.TryGetValue("chave", out var valor))
                            {
                                Console.WriteLine($"Valor recebido do cliente: {valor}");
                            }
                        }

                        // Continue lendo enquanto não atingir o fim da mensagem
                    } while (!receivedResult.EndOfMessage);

                    var usuarios = dbContext.tabUsuario.ToList();
                    var usuariosJson = JsonSerializer.Serialize(usuarios);

                    await webSocket.SendAsync(Encoding.UTF8.GetBytes(usuariosJson), WebSocketMessageType.Text, true, cancellationToken);

                    await Task.Delay(1000);
                }
                finally
                {
                    dbContext.Dispose();
                }
            }
        }
    }
    catch (Exception ex)
    {
    }
    finally
    {
        if (webSocket.State == WebSocketState.Open)
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken);
    }
});

await app.RunAsync();



