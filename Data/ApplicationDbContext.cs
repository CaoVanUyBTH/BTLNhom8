using Microsoft.EntityFrameworkCore;
using BTLNhom8.Models;
namespace BTLNhom8.Data;

    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<BTLNhom8.Models.Student> Student { get; set; } = default!;
        public DbSet<BTLNhom8.Models.Faculty> Faculty { get; set; } = default!;
    }
