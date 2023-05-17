using Microsoft.EntityFrameworkCore;
using WTFMessageAPI.Models;

namespace WTFMessageAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
