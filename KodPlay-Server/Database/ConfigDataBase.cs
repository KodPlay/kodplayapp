using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KodPlay_Server.Database.Read.Server
{
   
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //配置连接字符串
        {
            optionsBuilder.UseL();
            optionsBuilder.UseMySQL("Data Source=103.219.30.184;Database=sb;User ID=sb;Password=Mie123...;pooling=true;port=3306;sslmode=none;CharSet=utf8;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
