using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models;

public class Student
{
    public int Id { get; set; }
    [StringLength(50), Required, RegularExpression(@"^[A-Z][a-zA-Z]*$")] public string LastName { get; set; }
    [StringLength(50), Required, RegularExpression(@"^[A-Z][a-zA-Z]*$")] public string FirstMidName { get; set; }
    [DataType(DataType.Date)] [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] public DateTime EnrollmentDate { get; set; }
    [Display(Name = "Full Name"), NotMapped] public string FullName => $"{FirstMidName} {LastName}";
    public ICollection<Enrollment> Enrollments { get; set; }
}
