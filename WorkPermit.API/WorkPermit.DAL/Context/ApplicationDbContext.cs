using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WorkPermit.DAL.Config;
using WorkPermit.DAL.Models;

namespace WorkPermit.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<StatusModel> StatusModels { get; set; }
        public DbSet<WorkPermitRequest> WorkPermitRequests { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StatusModelConfiguration());
            modelBuilder.ApplyConfiguration(new WorkPermitConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var departments = JsonSerializer.Deserialize<List<Department>>(@"[
            {""Id"":1,""Name"":""IS""},
            {""Id"":2,""Name"":""CS""},
            {""Id"":3,""Name"":""DS""}
             ]") ?? new List<Department>();

            var Employees = JsonSerializer.Deserialize<List<Employee>>(@"[
            {""Id"":1,""Name"":""Mona"",""Role"":""Engineer""},
            {""Id"":2,""Name"":""Hossam"",""Role"":""Doctor""},
            {""Id"":3,""Name"":""Ali"",""Role"":""Teacher""}
             ]") ?? new List<Employee>();


            //            var WorkPermitRequests = JsonSerializer.Deserialize<List<WorkPermitRequest>>(@"[
            //    {""Id"":1,""EmployeeId"":1,""DepartmentId"":1,""StartDate"":""2022-01-01T08:00:00Z"",""EndDate"":""2022-01-02T08:00:00Z""},
            //    {""Id"":2,""EmployeeId"":2,""DepartmentId"":2,""StartDate"":""2022-01-03T08:00:00Z"",""EndDate"":""2022-01-04T08:00:00Z""},
            //    {""Id"":3,""EmployeeId"":3,""DepartmentId"":3,""StartDate"":""2022-01-05T08:00:00Z"",""EndDate"":""2022-01-06T08:00:00Z""}
            //]") ?? new List<WorkPermitRequest>();

            var activities = new List<Activity>
    {
        new Activity { Id = 1, Description = "Activity 1",WorkPermitRequestId=1},
        new Activity { Id = 2, Description = "Activity 2",WorkPermitRequestId=1 },
        new Activity { Id = 3, Description = "Activity 3",WorkPermitRequestId=2 },
        new Activity { Id = 4, Description = "Activity 4",WorkPermitRequestId=3},
        new Activity { Id = 5, Description = "Activity 5",WorkPermitRequestId=1 },
        new Activity { Id = 6, Description = "Activity 6",WorkPermitRequestId=1 }
    };

            var equipment = new List<Equipment>
    {
        new Equipment { Id = 1, Name = "Equipment 1" ,WorkPermitRequestId=1},
        new Equipment { Id = 2, Name = "Equipment 2" ,WorkPermitRequestId=2},
        new Equipment { Id = 3, Name = "Equipment 3" ,WorkPermitRequestId=1},
        new Equipment { Id = 4, Name = "Equipment 4" ,WorkPermitRequestId=1},
        new Equipment { Id = 5, Name = "Equipment 5",WorkPermitRequestId=3},
        new Equipment { Id = 6, Name = "Equipment 6" ,WorkPermitRequestId=2}
    };

            var workPermitRequests = new List<WorkPermitRequest>
    {
        new WorkPermitRequest
        {
            Id = 1,
            EmployeeId = 1,
            DepartmentId = 1,
            StartDate = new DateTime(2022, 1, 1, 8, 0, 0),
            EndDate = new DateTime(2022, 1, 2, 8, 0, 0)
        },
        new WorkPermitRequest
        {
            Id = 2,
            EmployeeId = 2,
            DepartmentId = 2,
            StartDate = new DateTime(2022, 1, 3, 8, 0, 0),
            EndDate = new DateTime(2022, 1, 4, 8, 0, 0)
        },
        new WorkPermitRequest
        {
            Id = 3,
            EmployeeId = 3,
            DepartmentId = 3,
            StartDate = new DateTime(2022, 1, 5, 8, 0, 0),
            EndDate = new DateTime(2022, 1, 6, 8, 0, 0)
        }
    };




            modelBuilder.Entity<Employee>().HasData(Employees);
            modelBuilder.Entity<Department>().HasData(departments);

            modelBuilder.Entity<Activity>().HasData(activities);
            modelBuilder.Entity<Equipment>().HasData(equipment);
            modelBuilder.Entity<WorkPermitRequest>().HasData(workPermitRequests);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
