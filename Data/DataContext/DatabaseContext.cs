using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.DataContext
{
    public class DatabaseContext : DbContext
    {
        public static OptionsBuild OpsBuild = new();
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            if (!(Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                 RelationalDatabaseFacadeExtensions.Migrate(Database); //create database if not existing and push all migrations
        }

        //db sets
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }

        public class OptionsBuild
        {
            public DbContextOptionsBuilder<DatabaseContext> OpsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DpOptions { get; set; }
            AppConfiguration Settings { get; set; }

            
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                OpsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                OpsBuilder.UseSqlServer(Settings.SqlConnectionString);
                DpOptions = OpsBuilder.Options;
            }
        }

    }
}
