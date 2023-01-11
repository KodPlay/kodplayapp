using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KodPlay_Server.Database.Read.Server
{
    [AppDbContext("MysqlConnectionString", DbProvider.Sqlite)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {

        }
    }
}
