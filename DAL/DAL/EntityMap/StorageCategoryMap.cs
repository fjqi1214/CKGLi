using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Model;


namespace DAL
{
    public class StorageCategoryMap
         : EntityTypeConfiguration<StorageCategory>
    {
        public StorageCategoryMap()
        {
            ToTable("StorageCategoryTable", "dbo");
            HasKey(t => t.StorageNumber);
            Property(t => t.StorageNumber)
            .HasColumnName("StorageNumber")
            .IsRequired();



            Property(t => t.Category)
           .HasColumnName("Category")
           .IsOptional();

            Property(t => t.Reserve)
            .HasColumnName("Reserve")
            .IsOptional();

        }
    }
}
