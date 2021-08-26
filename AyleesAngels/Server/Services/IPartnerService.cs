using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyleesAngels.Shared.Models;

namespace AyleesAngels.Server.Services
{
    public interface IPartnerService
    {
        Task<ServiceResponse<List<Partner>>> GetPartners();
        Task<ServiceResponse<Partner>> GetPartner(int id);
        Task<ServiceResponse<Partner>> AddPartner(Partner newPartner);
        Task<ServiceResponse<Partner>> UpdatePartner(Partner updatedPartner);
        Task<ServiceResponse<int>> DeletePartner(int id);
    }
}
