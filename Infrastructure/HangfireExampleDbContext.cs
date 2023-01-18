using Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class HangfireExampleDbContext: DbContext
    {
        public HangfireExampleDbContext(DbContextOptions<HangfireExampleDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Singer> Singers { get; set; }
    }
}
