using DAL.EF;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Employee"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DataContext>();

    // Seed your data here
    dbContext.Employees.AddRange(
        new Employee
        {
            EmployeeId = 502030,
            EmployeeName = "Mehedi Hasan",
            EmployeeCode = "EMP320",
            EmployeeSalary = 50000,
            SupervisorId = 502036
        },
            new Employee
            {
                EmployeeId = 502031,
                EmployeeName = "Ashikur Rahman",
                EmployeeCode = "EMP321",
                EmployeeSalary = 45000,
                SupervisorId = 502036
            },
            new Employee
            {
                EmployeeId = 502032,
                EmployeeName = "Rakibul Islam",
                EmployeeCode = "EMP322",
                EmployeeSalary = 52000,
                SupervisorId = 502030
            },
            new Employee
            {
                EmployeeId = 502033,
                EmployeeName = "Hasan Abdullah",
                EmployeeCode = "EMP323",
                EmployeeSalary = 46000,
                SupervisorId = 502031
            },
            new Employee
            {
                EmployeeId = 502034,
                EmployeeName = "Akib Khan",
                EmployeeCode = "EMP324",
                EmployeeSalary = 66000,
                SupervisorId = 502032
            },
            new Employee
            {
                EmployeeId = 502035,
                EmployeeName = "Rasel Shikder",
                EmployeeCode = "EMP325",
                EmployeeSalary = 53500,
                SupervisorId = 502033
            },
            new Employee
            {
                EmployeeId = 502036,
                EmployeeName = "Selim Reja",
                EmployeeCode = "EMP326",
                EmployeeSalary = 59000,
                SupervisorId = 502035
            }
    );

    dbContext.SaveChanges();
}*/

app.MapControllers();

app.Run();
