using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Domain.Interfaces.IQueryRepository;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;
using Resume.Infra.Data.MongoDb;
using Resume.Infra.Data.Repository;
using Resume.Infra.Data.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infra.Data.RepositoryQueries
{
    public class EducationQueryRepository :GenericQueryRepository<EducationViewModel>, IEducationQueryRepository
    {
        public EducationQueryRepository(MongoDbContext dbContext) : base(dbContext)
        {

        }
    }

}
