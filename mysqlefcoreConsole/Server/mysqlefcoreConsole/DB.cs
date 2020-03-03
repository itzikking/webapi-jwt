using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using mysqlefcoreConsole.Models;

namespace mysqlefcore
{
    public class DB : DbContext
    {
        public DbSet<Users> Users { get; set; }


        DbContextOptionsBuilder optionsBuilder;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = "localhost";
            var database = "serverdb";
            var user = "root";
            var password = "root";
            optionsBuilder.UseMySQL($"server={server};database={database};user={user};password={password}");
            this.optionsBuilder = optionsBuilder;
        }

        public DB()
        {
            optionsBuilder = new DbContextOptionsBuilder();
            OnConfiguring(optionsBuilder);
        }
    }
}