using Resume.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Resume.Domain.Models;

    namespace Resume.Domain.Interfaces.ICommandRepository
{
    public interface IEducationCommandRepository
    {
        Task<Education> AddAsync(Education entity, CancellationToken cancellationToken);

        void Delete(Education entity);

        void Update(Education entity);



    }
}
