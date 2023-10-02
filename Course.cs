
namespace _007_EF
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

        

        public Course(string name)
        {
            StudentCourses = new List<StudentCourse>();
            Name = name;
        }


    }
}
