using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EFCore_CordeFirst_Prac.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CordeFirst_Prac.Context;

class AppDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Lesson> Lessons { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<StudentProfile> StudentProfiles { get; set; } = null!;
    public DbSet<StudentCourses> StudentCourses { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CodeFirstPrac;Trusted_Connection=true;TrustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
