using Furion.DatabaseAccessor;
using KodPlay_Server.Database.Read.Server;
using KodPlay_Server.Server.ViewModels;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args).Inject();

builder.Services.AddControllers().AddInject();
builder.Services.AddRemoteRequest();
builder.Services.AddVirtualFileServer();//注册虚拟文件系统
builder.Services.AddSignalR();//注册 SignalR 服务
builder.Services.AddDatabaseAccessor(options =>
{
    //options.AddDbPool<DefaultDbContext>(connectionMetadata: "Data Source=103.219.30.184;Database=sb;User ID=sb;Password=Mie123...;pooling=true;port=3306;sslmode=none;CharSet=utf8;");
    options.AddDbPool<DefaultDbContext>(DbProvider.MySqlOfficial);
});//注册数据库EFCORE


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseInject();

app.MapControllers();

app.UseCors();
app.MapHub<OnlionHub>("/hubs/onlionhub");
app.Run();