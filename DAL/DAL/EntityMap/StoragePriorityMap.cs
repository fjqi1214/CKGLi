using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class StoragePriorityMap
         : EntityTypeConfiguration<StoragePriority>
    {
        public StoragePriorityMap()
        {
            ToTable("StoragePriorityTable", "dbo");

            HasKey(t => t.Id);
            Property(t => t.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .HasColumnName("Id")
            .IsRequired();

            Property(t => t.ManufacturerName)
           .HasColumnName("ManufacturerName")
           .IsRequired();

            Property(t => t.StorageNumber)
            .HasColumnName("StorageNumber")
            .IsRequired();


            Property(t => t.Priority)
            .HasColumnName("Priority")
            .IsRequired();


            Property(t => t.Reserve)
            .HasColumnName("Reserve")
            .IsRequired();

            HasRequired<Manufacturer>(t => t.Man)
                .WithMany(t => t.StoragePrioritys)
             .HasForeignKey(d => d.ManufacturerName)
             .WillCascadeOnDelete(false);

            HasRequired<StorageCategory>(t => t.Categroy)
               .WithMany(t => t.StoragePrioritys)
            .HasForeignKey(d => d.StorageNumber)
            .WillCascadeOnDelete(false);

           

        }
    }
}
