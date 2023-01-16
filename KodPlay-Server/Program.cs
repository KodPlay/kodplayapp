using Furion.DatabaseAccessor;
using Furion.Logging;
using Furion.Logging.Extensions;
using Furion.Schedule;
using Furion.Templates;
using KodPlay_Server.Control.Data.Log;
using KodPlay_Server.Control.Schedule;
using KodPlay_Server.Database.Read.Server;
using KodPlay_Server.Server.ViewModels;
using Microsoft.AspNetCore.SignalR;



var template = TP.Wrapper("KodPlay Server", "KodPlay 客户服务",
    "##Dev## 0X7E9FB Dev",
    "##当前版本## v1.0.0",
    "##文档地址## localhost Swagger Server",
    "##Copyright## 0X7E9FB Dev - Desk Stand ©");

Console.WriteLine(template);





var builder = WebApplication.CreateBuilder(args).Inject();

builder.Services.AddControllers().AddInject();
builder.Services.AddRemoteRequest();
builder.Logging.AddConsoleFormatter();//注册控制台日志标准化模板
builder.Services.AddVirtualFileServer();//注册虚拟文件系统
builder.Services.AddSignalR();//注册 SignalR 服务

builder.Services.AddConsoleFormatter(options =>
{
    options.DateFormat = "yyyy-MM-dd HH:mm:ss.fffffff zzz dddd";
});

//注册调度作业
builder.Services.AddSchedule(options =>
{
    options.AddJob(JobBuilder.Create<VerificationFilesJob>()
      .SetIncludeAnnotations(true)); //创建资产文件夹扫描JOB
});


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

