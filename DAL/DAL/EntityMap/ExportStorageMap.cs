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
           .IsOptional();


            Property(t => t.ProductName)
            .HasColumnName("ProductName")
            .IsOptional();

            Property(t => t.ManufacturerName)
            .HasColumnName("ManufacturerName")
            .IsOptional();


            Property(t => t.LotNumber)
            .HasColumnName("LotNumber")
            .IsOptional();


            Property(t => t.ExpNum)
            .HasColumnName("ExpNum")
            .IsOptional();

            Property(t => t.ExpTime)
            .HasColumnName("ExpTime")
            .IsOptional();

            Property(t => t.UnitNum)
            .HasColumnName("UnitNum")
            .IsOptional();

            Property(t => t.Reserve)
         .HasColumnName("Reserve")
         .IsOptional();


            HasOptional(t => t.Manu)
           .WithMany(t => t.Exps)
           .HasForeignKey(d => d.ManufacturerName)
           .WillCascadeOnDelete(false);

            HasOptional(t => t.StorageL)
              .WithMany(t => t.Exps)
              .HasForeignKey(d => d.LocationName)
              .WillCascadeOnDelete(false);

            HasOptional(t => t.Goods)
              .WithMany(t => t.Exps)
              .HasForeignKey(d => d.ProductName)
              .WillCascadeOnDelete(false);

        }



    }
}
