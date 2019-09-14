namespace P01_StudentSystem
{
    using System;

    using Data;
    using Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new StudentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                SeedCourses(context);
                SeedResources(context);
                SeedStudents(context);
                SeedStudentCourses(context);

            }
        }

        private static void SeedStudentCourses(StudentSystemContext context)
        {
            StudentCourse[] studentCourses =
            {
                new StudentCourse
                {
                    StudentId = 1,
                    CourseId = 1
                },
                new StudentCourse
                {
                    StudentId = 2,
                    CourseId = 1
                },
                new StudentCourse
                {
                    StudentId = 3,
                    CourseId = 4
                },
                new StudentCourse
                {
                    StudentId = 4,
                    CourseId = 1
                },
                new StudentCourse
                {
                    StudentId = 1,
                    CourseId = 3
                },
                new StudentCourse
                {
                    StudentId = 2,
                    CourseId = 3
                },
                new StudentCourse
                {
                    StudentId = 3,
                    CourseId = 3
                }
            };

            context.StudentCourses.AddRange(studentCourses);
            context.SaveChanges();
        }

        private static void SeedStudents(StudentSystemContext context)
        {
            Student[] students =
            {
                new Student
                {
                    Name = "Vasko",
                    RegisteredOn = DateTime.Now,
                },
                new Student
                {
                    Name = "Marin",
                    RegisteredOn = DateTime.Now,
                },
                new Student
                {
                    Name = "Svetlio",
                    RegisteredOn = DateTime.Now,
                },
                new Student
                {
                    Name = "Babcho",
                    RegisteredOn = DateTime.Now,
                },
                new Student
                {
                    Name = "Marin2",
                    RegisteredOn = DateTime.Now,
                },
                new Student
                {
                    Name = "Asen",
                    RegisteredOn = DateTime.Now,
                },
                new Student
                {
                    Name = "Pehlivan",
                    RegisteredOn = DateTime.Now,
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }

        private static void SeedResources(StudentSystemContext context)
        {
            Resource[] resources =
            {
                new Resource
                {
                    Name = "Video for programmers",
                    ResourceType = ResourceType.Video,
                    Url = "comming soon",
                    CourseId = 1
                },
                new Resource
                {
                    Name = "Presentation for programmers",
                    ResourceType = ResourceType.Presentation,
                    Url = "comming soon",
                    CourseId = 1
                },
                new Resource
                {
                    Name = "Presentation for new programmers",
                    ResourceType = ResourceType.Presentation,
                    Url = "comming soon",
                    CourseId = 1
                }
            };

            context.Resources.AddRange(resources);
            context.SaveChanges();
        }

        private static void SeedCourses(StudentSystemContext context)
        {
            Course[] courses =
            {
                new Course
                {
                    Name = "DB ez",
                    Description = "very easy course",
                    Price = 1100,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2020, 3, 18)
                },
                new Course
                {
                    Name = "My code",
                    Description = "Code course",
                    Price = 123,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2019, 12, 18)
                },
                new Course
                {
                    Name = "Course 5",
                    Description = "Just another course",
                    Price = 50,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2020, 1, 11)
                },
                new Course
                {
                    Name = "The Course",
                    Description = "The best and the most important course",
                    Price = 100000,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2019, 10, 1)
                },
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
    }
}
