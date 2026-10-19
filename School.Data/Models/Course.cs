using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;

public class Course
{
    public int CourseId { get; set; }
    [StringLength(50), MinLength(3)] public string Title { get; set; }
    [Range(0, 5)] public int Credits { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<CourseAssignment> CourseAssignments { get; set; }
}
