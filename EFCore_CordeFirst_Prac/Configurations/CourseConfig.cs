using EFCore_CordeFirst_Prac.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Configurations;

class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Description)
             .IsRequired()
             .HasMaxLength(1000);

        builder.ToTable
        (
            c => c.HasCheckConstraint
            (
                "CK_Course_Price", "[Price] >= 0"
            )
        );

        builder.HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

        builder.HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);
     }
}
