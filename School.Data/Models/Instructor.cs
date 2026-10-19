using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace School.Data.Models;

public class Instructor
{
    public int Id { get; set; }
    [StringLength(50), Required, RegularExpression(@"^[A-Z][a-zA-Z]*$")] public string LastName { get; set; }
    [StringLength(50), Required, RegularExpression(@"^[A-Z][a-zA-Z]*$")] public string FirstMidName { get; set; }
    [Display(Name = "Full Name"), NotMapped] public string FullName => $"{FirstMidName} {LastName}";
    [DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime HireDate { get; set; }
    public ICollection<CourseAssignment> CourseAssignments { get; set; }
    public OfficeAssignment OfficeAssignment { get; set; }
}

