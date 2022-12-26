using Moq;
using SkiProject.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Test.Mocks
{
    public static class RepositoryMock
    {
        public static IRepository Repo
        {
            get
            {
                var repo = new Mock<IRepository>();
                return repo.Object;
            }
        }
    }
}
