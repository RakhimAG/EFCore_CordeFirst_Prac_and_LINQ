using EFCore_CordeFirst_Prac.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Configurations;

class StudentProfilesConfig : IEntityTypeConfiguration<StudentProfile>
{
    public void Configure(EntityTypeBuilder<StudentProfile> builder)
    {
        builder.HasKey(sp => sp.Id);

        builder.HasOne(sp => sp.Student)
                .WithOne(s => s.Profile)
                .HasForeignKey<StudentProfile>(sp => sp.StudentId);

        builder.Property(sp => sp.Phone)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(sp => sp.DateOfBirth)
            .IsRequired();
    }
}
