using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;

public class Department
{
    public int DepartmentId { get; set; }
    [StringLength(50), MinLength(3)] public string Name { get; set; }
    [DataType(DataType.Currency), Column(TypeName = "money")] public decimal Budget { get; set; }
    [DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime StartDate { get; set; }
    [ForeignKey(nameof(Administrator))] public int? InstructorId { get; set; }
    public Instructor Administrator { get; set; }
    public ICollection<Course> Courses { get; set; }
}
