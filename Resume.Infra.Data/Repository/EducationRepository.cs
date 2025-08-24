using Resume.Domain.IRepository;
using Resume.Domain.Models;
using Resume.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {


        public EducationRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

    }
}
