using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Domain.Models;
using Resume.Infra.Data.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository
{
    public class EducationCommandRepository : GenericCommandRepository<Education>, IEducationCommandRepository
    {

        public EducationCommandRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

    }
}
