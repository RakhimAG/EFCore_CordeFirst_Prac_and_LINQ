using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Entities;

class StudentCourses
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public DateOnly EnrollmenDate { get; set; }
}
