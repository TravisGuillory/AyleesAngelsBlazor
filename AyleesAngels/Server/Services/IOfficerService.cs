using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyleesAngels.Shared.Models;

namespace AyleesAngels.Server.Services
{
    public interface IOfficerService
    {
        Task<ServiceResponse<List<Officer>>> GetOfficers();
        Task<ServiceResponse<Officer>> GetOfficer(int id);
        Task<ServiceResponse<Officer>> AddOfficer(Officer newOfficer);
        Task<ServiceResponse<Officer>> UpdateOfficer(Officer updatedOfficer);
        Task<ServiceResponse<int>> DeleteOfficer(int id);
    }
}
