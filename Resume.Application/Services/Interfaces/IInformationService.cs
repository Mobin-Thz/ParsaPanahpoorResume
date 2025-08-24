using Resume.Domain.Models;
using Resume.Domain.ViewModels.Information;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IInformationService
    {
        Task<InformationViewModel> GetInformation();
        Task<Information> GetInformationModel();
        Task<CreateOrEditInformationViewModel> FillCreateOrEditInformationViewModel();
        Task<bool> CreateOrEditInformation(CreateOrEditInformationViewModel information);
    }
}
