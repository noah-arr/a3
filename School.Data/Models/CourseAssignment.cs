using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace School.Data.Models;

[PrimaryKey(nameof(CourseID), nameof(InstructorID))]
public class CourseAssignment
{
    public int CourseID { get; set; }
    public int InstructorID { get; set; }
    [ForeignKey(nameof(CourseID))] public Course Course { get; set; }
    [ForeignKey(nameof(InstructorID))] public Instructor Instructor { get; set; }
}
