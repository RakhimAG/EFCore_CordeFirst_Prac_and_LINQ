using EFCore_CordeFirst_Prac.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Configurations;

class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasMany(t => t.Courses)
            .WithOne(c => c.Teacher)
            .HasForeignKey(c => c.TeacherId);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(128);

        builder.HasIndex(t => t.Email)
            .IsUnique();
    }
}
