using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EntityMap
{
    public class ExportStorageMap
        : EntityTypeConfiguration<ExportStorage>
    {

        public ExportStorageMap()
        {
            ToTable("IExportStorageTable", "dbo");
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


        }



    }
}
