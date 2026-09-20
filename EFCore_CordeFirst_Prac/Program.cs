using EFCore_CordeFirst_Prac.Entities;
using EFCore_CordeFirst_Prac.Context;
using Microsoft.EntityFrameworkCore;

#region Adding rows to DB
{
    //using var context = new AppDbContext();

    //var newStudents = new List<Student>
    //{
    //    new Student
    //    {
    //        Email = "ali1234@gmail.com",
    //        Name = "Ali"
    //    },
    //    new Student
    //    {
    //        Email = "Calal234@gmail.com",
    //        Name = "Calal"
    //    },
    //    new Student
    //    {
    //        Email = "MikeTyson@gmail.com",
    //        Name = "Mike"
    //    },
    //};

    //context.Students.AddRange(newStudents);
    //await context.SaveChangesAsync();

    //var studentProfiles = new List<StudentProfile>
    //{
    //    new StudentProfile
    //    {
    //        DateOfBirth = new DateOnly(2007, 05, 10),
    //        Phone = "+994213203466",
    //        StudentId = 1
    //    },
    //    new StudentProfile
    //    {
    //        DateOfBirth = new DateOnly(2007, 04, 12),
    //        Phone = "+994214443441",
    //        StudentId = 2
    //    },
    //    new StudentProfile
    //    {
    //        DateOfBirth = new DateOnly(2007, 03, 20),
    //        Phone = "+994213203412",
    //        StudentId = 3
    //    }
    //};

    //context.StudentProfiles.AddRange(studentProfiles);
    //await context.SaveChangesAsync();

    //var newTeachers = new List<Teacher>
    //{
    //    new Teacher
    //    {
    //        Name = "Messi",
    //        Email = "MessiCourse@gmail.com"
    //    },
    //    new Teacher
    //    {
    //        Name = "Pele",
    //        Email = "Pele7@email.com"
    //    }
    //};

    //context.Teachers.AddRange(newTeachers);
    //await context.SaveChangesAsync();

    //var newCourses = new List<Course>
    //{
    //    new Course
    //    {
    //        TeacherId = 1,
    //        Name = "C# Fundamentals",
    //        Description = "Learn the basics of C# programming and object-oriented programming.",
    //        Price = 99.99m
    //    },
    //    new Course
    //    {
    //        TeacherId = 2,
    //        Name = "Entity Framework Core",
    //        Description = "Learn how to work with databases using EF Core.",
    //        Price = 129.99m
    //    },
    //    new Course
    //    {
    //        TeacherId = 1,
    //        Name = "SQL Server Essentials",
    //        Description = "Learn SQL, database design, queries, and relationships.",
    //        Price = 89.99m
    //    },
    //    new Course
    //    {
    //        TeacherId = 2,
    //        Name = "ASP.NET Core Web API",
    //        Description = "Build RESTful web APIs using ASP.NET Core.",
    //        Price = 149.99m
    //    }
    //};

    //context.Courses.AddRange(newCourses);
    //await context.SaveChangesAsync();

    //var studentCourses = new List<StudentCourses>
    //{
    //    new() { StudentId = newStudents[0].Id, CourseId = newCourses[0].Id },
    //    new() { StudentId = newStudents[0].Id, CourseId = newCourses[1].Id },

    //    new() { StudentId = newStudents[1].Id, CourseId = newCourses[1].Id },
    //    new() { StudentId = newStudents[1].Id, CourseId = newCourses[2].Id },

    //    new() { StudentId = newStudents[2].Id, CourseId = newCourses[3].Id }
    //};

    //context.StudentCourses.AddRange(studentCourses);
    //await context.SaveChangesAsync();

    //var newLessons = new List<Lesson>
    //{
    //    new Lesson
    //    {
    //        Title = "Introduction to C#",
    //        Duration = 45,
    //        CourseId = 1
    //    },
    //    new Lesson
    //    {
    //        Title = "Variables and Data Types",
    //        Duration = 50,
    //        CourseId= 1
    //    },
    //    new Lesson
    //    {
    //        Title = "Building REST APIs with ASP.NET Core",
    //        Duration = 60,
    //        CourseId= 4,
    //    },
    //    new Lesson
    //    {
    //        CourseId= 4,
    //        Title = "Introduction to ASP.NET Core",
    //        Duration = 55
    //    },
    //    new Lesson
    //    {
    //        CourseId= 2,
    //        Title = "Introduction to Entity Framework Core",
    //        Duration = 50
    //    },
    //    new Lesson
    //    {
    //        CourseId= 2,
    //        Title = "Working with DbContext",
    //        Duration = 45
    //    },
    //    new Lesson
    //    {
    //        CourseId= 3,
    //        Title = "LINQ and Database Queries",
    //        Duration = 65
    //    },
    //    new Lesson
    //    {
    //        CourseId= 3,
    //        Title = "Relationships in EF Core",
    //        Duration = 70
    //    }
    //};

    //context.Lessons.AddRange(newLessons);
    //await context.SaveChangesAsync();
}
#endregion


using var context = new AppDbContext();
// 1 Получить всех студентов вместе с их профилями
{
    var students = await context.Students
                           .Include(s => s.Profile)
                           .ToListAsync();
}

// 2 Получить все курсы вместе с преподавателем
{
    var courses = await context.Courses
                            .Include(t => t.Teacher)
                            .ToListAsync();
}

// 3 получить курс вместе со всеми его уроками
{
    var courses = await context.Courses
                                .Include(c => c.Lessons)
                                .ToListAsync();
}

// 4 Получить курс вместе с преподавателем и уроками
{
    var courses = await context.Teachers
                                .Include(t => t.Courses)
                                .ThenInclude(c => c.Lessons)
                                .ToListAsync(); 
}

// 5 Получить всех студентов определённого курса.
{
    int courseId = 1;
    var students = await context.Students
                                .Where
                                (
                                    s => s.StudentCourses.Any(sc=>  sc.CourseId == courseId)
                                )
                                .ToListAsync();
}

// 6 Получить количество студентов на каждом курсе.
{
    var studentCountInEachCourse = await context.StudentCourses
                                           .GroupBy(sc => sc.CourseId)
                                           .Select(
                                                g => new {
                                                    CourseId = g.Key,
                                                    StudentCount = g.Count()
                                                }
                                           )
                                           .ToListAsync();

    foreach(var i in studentCountInEachCourse)
        Console.WriteLine($"Course Id : {i.CourseId} | Student Count : {i.StudentCount}");
}
