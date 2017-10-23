using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WarehouseSystem.DataAccess
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext() : base("name=WarehouseContext")
        {
            Database.CreateIfNotExists();
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductModel> ProductModels { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<Warehouse> Warehouses { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    // Configure Student & StudentAddress entity
        //    modelBuilder.Entity<Product>()
        //        .HasOptional(s => s.Location) // Mark Address property optional in Student entity
        //        .WithRequired(ad => ad.Products); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

        //}
    }
}
