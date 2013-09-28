using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace DAL
{
    public class UserMap
        : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("UserTable", "dbo");
            HasKey(t => t.UserName);
            Property(t => t.UserName)
            .HasColumnName("UserName")
            .IsRequired();

            Property(t => t.Auth)
         .HasColumnName("Auth")
         .IsRequired();

            Property(t => t.Pwd)
      .HasColumnName("Pwd")
      .IsRequired();
        }


    }
}
