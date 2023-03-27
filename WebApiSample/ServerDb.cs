using Microsoft.EntityFrameworkCore;
using WebApiSample.Models;

namespace WebApiSample
{
    public class ServerDb : DbContext
    {

        public ServerDb(DbContextOptions<ServerDb> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CatalogueItem> CatalogueItems { get; set; }
        public DbSet<StockItem> StockItems { get; set; }




        //// Overriding OnConfiguring Method

        //private readonly IConfiguration config;

        //public ServerDb(IConfiguration config)
        //{
        //    this.config = config;
        //}

        //public DbSet<User> Users { get; set; }
        //public DbSet<CatalogueItem> CatalogueItems { get; set; }
        //public DbSet<StockItem> StockItems { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;database=workshop_db");
        //    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //}
    }
}
