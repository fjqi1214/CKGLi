using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class ExportStorageMap
        : EntityTypeConfiguration<ExportStorage>
    {

        public ExportStorageMap()
        {
            ToTable("ExportStorageTable", "dbo");
            HasKey(t => t.Id);
            Property(t => t.Id)
            .HasColumnName("Id")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .IsRequired();


            Property(t => t.LocationName)
           .HasColumnName("LocationName")
           .IsRequired();


            Property(t => t.ProductName)
            .HasColumnName("ProductName")
            .IsRequired();

            Property(t => t.ManufacturerName)
            .HasColumnName("ManufacturerName")
            .IsRequired();


            Property(t => t.LotNumber)
            .HasColumnName("LotNumber")
            .IsRequired();


            Property(t => t.ExpNum)
            .HasColumnName("ExpNum")
            .IsRequired();

            Property(t => t.ExpTime)
            .HasColumnName("ExpTime")
            .IsRequired();

            Property(t => t.UnitNum)
            .HasColumnName("UnitNum")
            .IsRequired();

            Property(t => t.Reserve)
         .HasColumnName("Reserve")
         .IsOptional();


            HasRequired(t => t.Manu)
           .WithMany(t => t.Exps)
           .HasForeignKey(d => d.ManufacturerName)
           .WillCascadeOnDelete(false);

            HasRequired(t => t.StorageL)
              .WithMany(t => t.Exps)
              .HasForeignKey(d => d.LocationName)
              .WillCascadeOnDelete(false);

            HasRequired(t => t.Goods)
              .WithMany(t => t.Exps)
              .HasForeignKey(d => d.ProductName)
              .WillCascadeOnDelete(false);

        }



    }
}
