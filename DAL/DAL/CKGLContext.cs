using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;
using DAL;

namespace DAL
{
    public class CKGLContext:DbContext
    {
        public DbSet<CheckRecord> CheckRecords { get; set; }

        public DbSet<ExportStorage> ExportStorages { get; set; }

        public DbSet<ImportStorage> ImportStorages { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<StorageLocation> StorageLocations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<StorageCategory> StorageCategorys { get; set; }

        public DbSet<GoodsDetail> GoodsDetails { get; set; }

        public DbSet<StoragePriority> StoragePrioritys { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ImportStorageMap());
            modelBuilder.Configurations.Add(new CheckRecordMap());
            modelBuilder.Configurations.Add(new ExportStorageMap());
            modelBuilder.Configurations.Add(new GoodsDetailMap());
            modelBuilder.Configurations.Add(new ManufacturerMap());
            modelBuilder.Configurations.Add(new StorageCategoryMap());
            modelBuilder.Configurations.Add(new StorageLocationMap());
            modelBuilder.Configurations.Add(new StoragePriorityMap());
            modelBuilder.Configurations.Add(new UserMap());
            Database.SetInitializer<CKGLContext>(new CKGLInitializer());
            
            //Database.SetInitializer<CKGLContext>(new ProductInitializer());
            //Database.SetInitializer<CKGLContext>(new ImportStorageInitializer());

           
        }

    }
}
