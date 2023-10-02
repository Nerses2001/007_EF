using _007_EF;
using Microsoft.EntityFrameworkCore;

using (Context context = new())
{
    Student student1 = new("Student_1");


    Student student2 = new("Student_2");

    Student student3 = new("Student_3");

    context.Students.AddRange(student1, student2, student3);


    Course course1 = new("Physics_1");

    Course course2 = new("Physics_2");

    Course course3 = new ("Physics_3");

    context.Courses.AddRange(course1, course2, course3);

    context.SaveChanges();


    student2.StudentCourses.Add(new StudentCourse(course1.Id, student2.Id));

    student3.StudentCourses.Add(new StudentCourse(course2.Id,student3.Id));

    student1.StudentCourses.Add(new StudentCourse(course3.Id, student1.Id));

    context.SaveChanges();

    var courses = context.Courses
        .Include(x => x.StudentCourses)
        .ThenInclude(y => y.Student)
        .ToList();

    foreach (var item in courses)
    {
        Console.WriteLine(item.Name);

        var students = item.StudentCourses
            .Select(x => x.Student)
            .ToList();

        foreach (var student in students)
        {
            Console.WriteLine(student!.Name);
        }
    }

}
Console.ReadLine();