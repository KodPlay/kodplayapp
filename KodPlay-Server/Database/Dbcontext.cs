using Furion.DatabaseAccessor;
using KodPlay_Server.Database.Read.Server;
using Microsoft.EntityFrameworkCore;

namespace KodPlay_Server.Database
{
    [AppDbContext("MysqlConnectionString", DbProvider.MySql)]
    public class SbDbContext : AppDbContext<SbDbContext>
    {
        public SbDbContext(DbContextOptions<SbDbContext> options) : base(options)
        {
        }
    }
}
