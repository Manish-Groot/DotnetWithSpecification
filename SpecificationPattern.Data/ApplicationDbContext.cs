using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpecificationPattern.Core.Entities;

namespace SpecificationPattern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}



//using Microsoft.EntityFrameworkCore;
//using SpecificationPattern.Core.Entities;

//namespace SpecificationPattern.Data
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
//        {
//        }

//        public DbSet<Developer> Developers { get; set; }
//        // Add other DbSets for additional entities if needed

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Configure entities, relationships, constraints if needed
//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}
