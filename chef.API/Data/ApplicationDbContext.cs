using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chef.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace chef.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}