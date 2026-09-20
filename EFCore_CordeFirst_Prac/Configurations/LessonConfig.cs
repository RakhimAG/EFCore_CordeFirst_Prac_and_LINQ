using EFCore_CordeFirst_Prac.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Configurations;

class LessonConfig : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Id);

        builder.ToTable
        (
            l => l.HasCheckConstraint
            (
                "CK_Lessons_Duration", "[Duration] > 0"
            )
        );

        builder.Property(l => l.Title)
            .IsRequired()
            .HasMaxLength(128);
    }
}
