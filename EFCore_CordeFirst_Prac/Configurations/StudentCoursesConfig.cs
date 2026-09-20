using EFCore_CordeFirst_Prac.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Configurations;

internal class StudentCoursesConfig : IEntityTypeConfiguration<StudentCourses>
{
    public void Configure(EntityTypeBuilder<StudentCourses> builder)
    {
        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

        builder.HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

        builder.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

        builder.Property(sc => sc.EnrollmenDate)
            .IsRequired()
            .HasDefaultValueSql("CAST(GETDATE() AS date)");
    }
}
