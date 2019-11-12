using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; } = new HashSet<StudentCourse>();
        public ICollection<Homework> HomeworkSubmissions { get; set; } = new HashSet<Homework>();
    }
}
