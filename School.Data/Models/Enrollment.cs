using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace School.Data.Models;

public enum Grade { A, B, C, D, E, F}

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public Grade? Grade { get; set; }
    [ForeignKey(nameof(CourseId))] public Course Course { get; set; }
    [ForeignKey(nameof(StudentId))] public Student Student { get; set; }
}
