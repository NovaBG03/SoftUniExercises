namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;

    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<EmployeeTask> EmployeesTasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(emp =>
            {
                emp.HasKey(e => e.Id);

                emp.Property(e => e.Username)
                    .HasMaxLength(40)
                    .IsRequired();

                emp.Property(e => e.Email)
                    .IsRequired();

                emp.Property(e => e.Phone)
                    .IsRequired();
            });

            modelBuilder.Entity<Project>(prj =>
            {
                prj.HasKey(p => p.Id);

                prj.Property(p => p.Name)
                    .HasMaxLength(40)
                    .IsRequired();
            });

            modelBuilder.Entity<Task>(tsk =>
            {
                tsk.HasKey(t => t.Id);

                tsk.Property(t => t.Name)
                    .HasMaxLength(40)
                    .IsRequired();

                tsk.HasOne(t => t.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(t => t.ProjectId);
            });

            modelBuilder.Entity<EmployeeTask>(empTsk =>
            {
                empTsk.HasKey(et => new { et.EmployeeId, et.TaskId});

                empTsk.HasOne(et => et.Employee)
                    .WithMany(e => e.EmployeesTasks)
                    .HasForeignKey(et => et.EmployeeId);

                empTsk.HasOne(et => et.Task)
                    .WithMany(t => t.EmployeesTasks)
                    .HasForeignKey(et => et.TaskId);
            });
        }
    }
}