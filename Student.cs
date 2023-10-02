
namespace _007_EF
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public Student(string name) 
        {
            Name = name;
            StudentCourses = new List<StudentCourse>();

        }
    }
}
