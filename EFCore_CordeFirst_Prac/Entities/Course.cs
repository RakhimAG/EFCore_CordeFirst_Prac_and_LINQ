using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Entities;

class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public List<StudentCourses> StudentCourses { get; set; }
    public List<Lesson> Lessons { get; set; }
}
