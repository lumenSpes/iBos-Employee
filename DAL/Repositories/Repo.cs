using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repo
    {
        public DataContext db;
        public Repo()
        {
            // Set up DbContextOptions for in-memory database
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Employee")
                .Options;

            db = new DataContext(options);
        }
    }
}
