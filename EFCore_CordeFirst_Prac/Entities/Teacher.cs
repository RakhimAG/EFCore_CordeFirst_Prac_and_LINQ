using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Entities;

class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Course> Courses { get; set; }
}
