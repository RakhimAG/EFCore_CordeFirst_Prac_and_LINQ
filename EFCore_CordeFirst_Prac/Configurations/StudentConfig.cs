using EFCore_CordeFirst_Prac.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Configurations;

internal class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(s => s.Email)
            .IsRequired();

        builder.HasIndex(s => s.Email)
            .IsUnique();
    }
}
