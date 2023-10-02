﻿
namespace _007_EF
{
    internal class StudentCourse
    {
        public int StudentId { get; set; }
        public Student ?Student { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public StudentCourse(int studentId, int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
