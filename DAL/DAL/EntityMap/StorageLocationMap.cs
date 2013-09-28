using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace DAL
{
    public class StorageLocationMap
           : EntityTypeConfiguration<StorageLocation>
    {
        public StorageLocationMap()
        {
            ToTable("StorageLocationTable", "dbo");
            HasKey(t => t.LocationName);
            Property(t => t.LocationName)
            .HasColumnName("LocationName")
            .IsRequired();

            Property(t => t.ManufacturerName)
            .HasColumnName("ManufacturerName")
            .IsOptional();


            Property(t => t.CategoryName)
           .HasColumnName("CategoryName")
           .IsRequired();

            Property(t => t.ProductName)
            .HasColumnName("ProductName")
            .IsOptional();

            Property(t => t.Reserve)
            .HasColumnName("Reserve")
            .IsOptional();

            Property(t => t.CanUse)
            .HasColumnName("CanUse")
            .IsOptional();


            HasRequired(t => t.Category)
                .WithMany(t => t.StorageLocations)
                .HasForeignKey(d => d.CategoryName)
                .WillCascadeOnDelete(false);

        }

    }
}
