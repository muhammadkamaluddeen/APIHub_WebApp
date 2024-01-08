using APIHub_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace APIHub_WebApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MUHAMMAD-KAMAL\\SQLEXPRESS;Database=CodeFirstDB;Integrated Security=true; TrustServerCertificate = true ");
        }

    } 
}
