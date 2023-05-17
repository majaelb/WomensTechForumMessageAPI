using Microsoft.EntityFrameworkCore;
using WTFMessageAPI.Models;

namespace WTFMessageAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=MessageAPI;Trusted_Connection=True; Encrypt=false");
        }
    }
}
