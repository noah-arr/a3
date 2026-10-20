using Microsoft.EntityFrameworkCore;
using School.Data.Data;
using School.Data.Models;

namespace School.Web.Data;

public class SeedData
{
    private readonly SchoolContext _context;

    public SeedData(SchoolContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (await _context.Students.AnyAsync()) return;

        var students = new List<Student>
        {
            new() { FirstMidName = "Ava",  LastName = "Nguyen",   EnrollmentDate = new DateTime(2024, 2, 5) },
            new() { FirstMidName = "Liam", LastName = "Patel",    EnrollmentDate = new DateTime(2024, 2, 5) },
            new() { FirstMidName = "Mia",  LastName = "Chen",     EnrollmentDate = new DateTime(2023, 7, 17) },
            new() { FirstMidName = "Noah", LastName = "Williams", EnrollmentDate = new DateTime(2023, 7, 17) },
            new() { FirstMidName = "Zoe",  LastName = "Martin",   EnrollmentDate = new DateTime(2025, 2, 3) }
        };

        var instructors = new List<Instructor>
        {
            new() { FirstMidName = "Sarah",  LastName = "Kim",     HireDate = new DateTime(2015, 3, 1) },
            new() { FirstMidName = "Daniel", LastName = "Brown",   HireDate = new DateTime(2018, 8, 20) },
            new() { FirstMidName = "Priya",  LastName = "Sharma",  HireDate = new DateTime(2012, 1, 9) },
            new() { FirstMidName = "Marcus", LastName = "Lee",     HireDate = new DateTime(2020, 6, 15) },
            new() { FirstMidName = "Elena",  LastName = "Rossi",   HireDate = new DateTime(2010, 11, 30) }
        };

        var departments = new List<Department>
        {
            new() { Name = "Computer Science", Budget = 250000m, StartDate = new DateTime(2010, 1, 1), Administrator = instructors[0] },
            new() { Name = "Mathematics",      Budget = 180000m, StartDate = new DateTime(2008, 1, 1), Administrator = instructors[2] },
            new() { Name = "Engineering",      Budget = 320000m, StartDate = new DateTime(2012, 1, 1), Administrator = instructors[1] },
            new() { Name = "Business",         Budget = 210000m, StartDate = new DateTime(2014, 1, 1), Administrator = instructors[3] },
            new() { Name = "Design",           Budget = 120000m, StartDate = new DateTime(2016, 1, 1), Administrator = instructors[4] }
        };

        var courses = new List<Course>
        {
            new() { Title = "Introduction to Programming", Credits = 3, Department = departments[0] },
            new() { Title = "Database Systems",            Credits = 4, Department = departments[0] },
            new() { Title = "Calculus",                    Credits = 3, Department = departments[1] },
            new() { Title = "Structural Design",           Credits = 4, Department = departments[2] },
            new() { Title = "Project Management",          Credits = 2, Department = departments[3] }
        };

        // PK is InstructorID (also the FK), so setting the Instructor navigation is enough
        var offices = new List<OfficeAssignment>
        {
            new() { Instructor = instructors[0], Location = "Building 14, Room 2.05" },
            new() { Instructor = instructors[1], Location = "Building 14, Room 2.11" },
            new() { Instructor = instructors[2], Location = "Building 9, Room 1.03" },
            new() { Instructor = instructors[3], Location = "Building 3, Room 4.20" },
            new() { Instructor = instructors[4], Location = "Building 7, Room 0.15" }
        };

        // composite key (CourseID + InstructorID), so each pair must be unique
        var courseAssignments = new List<CourseAssignment>
        {
            new() { Course = courses[0], Instructor = instructors[0] },
            new() { Course = courses[1], Instructor = instructors[0] },
            new() { Course = courses[2], Instructor = instructors[2] },
            new() { Course = courses[3], Instructor = instructors[1] },
            new() { Course = courses[4], Instructor = instructors[3] }
        };

        var enrollments = new List<Enrollment>
        {
            new() { Student = students[0], Course = courses[0], Grade = Grade.A },
            new() { Student = students[0], Course = courses[1], Grade = Grade.B },
            new() { Student = students[1], Course = courses[0], Grade = null },   // not graded yet
            new() { Student = students[2], Course = courses[2], Grade = Grade.C },
            new() { Student = students[3], Course = courses[4], Grade = Grade.A }
        };

        _context.Students.AddRange(students);
        _context.Instructors.AddRange(instructors);
        _context.Departments.AddRange(departments);
        _context.Courses.AddRange(courses);
        _context.OfficeAssignments.AddRange(offices);
        _context.CoursesAssignments.AddRange(courseAssignments);
        _context.Enrollments.AddRange(enrollments);

        await _context.SaveChangesAsync();
    }
}