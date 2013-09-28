using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace DAL
{
    public class GoodsDetailMap
         : EntityTypeConfiguration<GoodsDetail>
    {
        public GoodsDetailMap()
        {
            ToTable("GoodsDetailTable", "dbo");
            HasKey(t => t.GoodsName);
            Property(t => t.GoodsName)
            .HasColumnName("GoodsName")
            .IsRequired();

            Property(t => t.ManufacturerName)
            .HasColumnName("ManufacturerName")
            .IsOptional();

            Property(t => t.Units)
           .HasColumnName("Units")
           .IsOptional();


            Property(t => t.EffectiveDate)
           .HasColumnName("EffectiveDate")
           .IsOptional();

            Property(t => t.Reserve1)
           .HasColumnName("Reserve1")
           .IsOptional();

            Property(t => t.Reserve2)
            .HasColumnName("Reserve2")
            .IsOptional();

            HasOptional(t => t.Manu)
                  .WithMany(t => t.GoodsDetails)
                  .HasForeignKey(d => d.ManufacturerName)
                  .WillCascadeOnDelete(false);



        }
    }
}
