using Furion.DatabaseAccessor;
using KodPlay_Server.Database.Read.Server;

var builder = WebApplication.CreateBuilder(args).Inject();

builder.Services.AddControllers().AddInject();
builder.Services.AddRemoteRequest();
builder.Services.AddDatabaseAccessor(options =>
{
    options.AddDbPool<DefaultDbContext>(DbProvider.MySqlOfficial);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseInject();

app.MapControllers();

app.Run();