using Microsoft.EntityFrameworkCore;
using UdemyWebApiProject.Entities;

namespace UdemyWebApiProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUser { get; set; }
    }
}
