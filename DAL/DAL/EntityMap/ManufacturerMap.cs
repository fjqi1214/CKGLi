using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DAL;
using Model;

namespace DAL
{
    public class ManufacturerMap
         : EntityTypeConfiguration<Manufacturer>
    {
        public ManufacturerMap()
        {
            ToTable("ManufacturerTable", "dbo");

            HasKey(t => t.ManufacturerName);
            Property(t => t.ManufacturerName)
            .HasColumnName("ManufacturerName")
            .IsRequired();


            Property(t => t.Memo)
            .HasColumnName("Memo")
            .IsOptional();

            Property(t => t.Reserve)
            .HasColumnName("Reserve")
            .IsOptional();




        }

    }
}
