using MediatR;
using Resume.Application.Common.Interfaces;
using Resume.Application.CQRS.Education.Command.CreateEducation;
using Resume.Application.CQRS.Education.Command.DeleteEducation;
using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.CQRS.Education.Command.DeleteCommandHandler
{
    public class DeleteEducationHandler : IRequestHandler<DeleteEducationcommand, bool>
    {

        #region ctor
        private readonly IEducationCommandRepository _educationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEducationHandler(IEducationCommandRepository educationRepository, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;
            _unitOfWork = unitOfWork;

        }
        #endregion


        public async Task<bool> Handle(DeleteEducationcommand request, CancellationToken cancellationToken)
        {
            var education = new Resume.Domain.Models.Education { Id = request.Id };
            _educationRepository.Delete(education);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
