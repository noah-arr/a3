using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace School.Data.Models;

public class OfficeAssignment
{
    [Key]
    public int InstructorID { get; set; } 
    [StringLength(50)] public string Location { get; set; }
    [ForeignKey(nameof(InstructorID))] public Instructor Instructor { get; set; }
}

