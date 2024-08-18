using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Model
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department() { DepartmentId = 1, DepartmentName = "IT" },
                new Department() { DepartmentId = 2, DepartmentName = "Account" },
                new Department() { DepartmentId = 3, DepartmentName = "HR" },
                new Department() { DepartmentId = 4, DepartmentName = "Marketing" }
                );

            modelBuilder.Entity<Employee>().HasData(
            new Employee()
            {
                EmployeeId = 1,
                FirstName = "Reazul Islam",
                LastName = "Rana",
                DateofBirth = System.DateTime.Now,
                Email = "Rana@gmail.com",
                Gender = Gender.Male,
                PhotoPath = "Images/img10.jpg",
                DepartmentId = 1,
            },

                new Employee()
                {
                    EmployeeId = 2,

                    FirstName = "Moushumee",
                    LastName = "Mollika",
                    DateofBirth = System.DateTime.Now,
                    Email = "Moushumee@gmail.com",
                    Gender = Gender.Female,
                    PhotoPath = "Images/img11.jpg",
                    DepartmentId = 1,
                },
                        new Employee()
                        {
                            EmployeeId = 3,

                            FirstName = "Ibrahim Rihan",
                            LastName = "Ayat",
                            DateofBirth = System.DateTime.Now,
                            Email = "Ibrahim@gmail.com",
                            Gender = Gender.Male,
                            PhotoPath = "Images/img12.jpg",
                            DepartmentId = 1,
                        },
                                     new Employee()
                                     {
                                         EmployeeId = 4,

                                         FirstName = "Milon",
                                         LastName = "Ahmed",
                                         DateofBirth = System.DateTime.Now,
                                         Email = "Milon@gmail.com",
                                         Gender = Gender.Male,
                                         PhotoPath = "Images/img9.jpg",
                                         DepartmentId = 1,
                                     }
                );

        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
