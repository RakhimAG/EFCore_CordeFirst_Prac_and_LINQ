using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CordeFirst_Prac.Entities;

class StudentProfile
{
    public int Id { get; set; }
    public string Phone{ get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
}
