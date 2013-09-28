﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class ImportStorageMap
        : EntityTypeConfiguration<ImportStorage>
    {
        public ImportStorageMap()
        {
            ToTable("ImportStorageTable", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
             .HasColumnName("Id")
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
             .IsRequired();

            Property(t => t.ManufacturerName)
            .HasColumnName("ManufacturerName")
            .IsOptional();

            Property(t => t.LocationName)
             .HasColumnName("LocationName")
             .IsOptional();

            Property(t => t.ProductName)
            .HasColumnName("ProductName")
            .IsOptional();

            Property(t => t.LotNum)
           .HasColumnName("LotNum")
           .IsRequired();

            Property(t => t.ProductTime)
             .HasColumnName("ProductTime")
             .IsRequired();

            Property(t => t.ArrivalTime)
            .HasColumnName("ArrivalTime")
            .IsRequired();

            Property(t => t.Number)
             .HasColumnName("Number")
             .IsRequired();


            Property(t => t.MaterialNo)
            .HasColumnName("MaterialNo")
            .IsRequired();

            Property(t => t.UnitNum)
            .HasColumnName("UnitNum")
            .IsRequired();

            Property(t => t.Reserve)
            .HasColumnName("Reserve")
            .IsOptional();


            HasOptional(t => t.Manu)
                .WithMany(t => t.Imports)
                .HasForeignKey(d => d.ManufacturerName)
                .WillCascadeOnDelete(false);

            HasOptional(t => t.StorageL)
              .WithMany(t => t.Imports)
              .HasForeignKey(d => d.LocationName)
              .WillCascadeOnDelete(false);

            HasOptional(t => t.Goods)
              .WithMany(t => t.Imports)
              .HasForeignKey(d => d.ProductName)
              .WillCascadeOnDelete(false);

        }

    }
}
