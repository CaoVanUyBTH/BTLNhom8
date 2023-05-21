using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTLNhom8.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BTLNhom8.Models.Monhoc> Monhoc { get; set; } = default!;

        public DbSet<BTLNhom8.Models.Student> Student { get; set; } = default!;

        public DbSet<BTLNhom8.Models.Faculty> Faculty { get; set; } = default!;
    }
