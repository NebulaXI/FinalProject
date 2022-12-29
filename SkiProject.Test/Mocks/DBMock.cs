using Microsoft.EntityFrameworkCore;
using SkiProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Test.Mocks
{
    public static class DBMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}
