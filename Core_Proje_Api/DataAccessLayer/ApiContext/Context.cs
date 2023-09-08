using Core_Proje_Api.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.DataAccessLayer.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=CoreProjeDB2;integrated security=true;");
        }

        public DbSet<Category> Categories{ get; set; }
    }
}
