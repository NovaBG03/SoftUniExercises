namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;

    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=DESKTOP-RBLV7OL;Database=StudentSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnStudentCreating(modelBuilder);

            this.OnCourseCreating(modelBuilder);

            this.OnResourceCreating(modelBuilder);

            this.OnHomeworkCreating(modelBuilder);

            this.OnStudentCourseCreating(modelBuilder);
        }

        private void OnStudentCourseCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<StudentCourse>()
               .ToTable("StudentsCourses");

            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder
                .Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder
                .Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId);
        }

        private void OnHomeworkCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Homework>()
                .ToTable("Homeworks");

            modelBuilder
                .Entity<Homework>()
                .HasKey(h => h.HomeworkId);

            modelBuilder
                .Entity<Homework>()
                .Property(h => h.Content)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder
                .Entity<Homework>()
                .HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

            modelBuilder
                .Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);
        }

        private void OnResourceCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Resource>()
                .ToTable("Resources");

            modelBuilder
                .Entity<Resource>()
                .HasKey(r => r.ResourceId);

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder
                .Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);
        }

        private void OnCourseCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                   .Entity<Course>()
                   .ToTable("Courses");

            modelBuilder
                .Entity<Course>()
                .HasKey(c => c.CourseId);

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Description)
                .IsUnicode();
        }

        private void OnStudentCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Student>()
               .ToTable("Students");

            modelBuilder
                .Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder
                .Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .IsUnicode(false)
                .IsRequired(false);
        }
    }
}
