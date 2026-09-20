using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Entities;

class Lesson
{
    public int Id { get; set; }
    public string Title{ get; set; }
    // Duration -> how many minutes are in the lesson
    public int Duration{ get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}
