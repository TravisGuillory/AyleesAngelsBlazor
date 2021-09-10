using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyleesAngels.Server.Data;
using AyleesAngels.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AyleesAngels.Server.Services
{
    public class OfficerService : IOfficerService
    {
        private OfficerDbContext _context;

        public OfficerService(OfficerDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Officer>>> GetOfficers()
        {
            ServiceResponse<List<Officer>> serviceResponse = new ServiceResponse<List<Officer>>();
            serviceResponse.Data = await _context.Officers.ToListAsync();
            try
            {
                serviceResponse.Data = await _context.Officers.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<Officer>> AddOfficer(Officer newOfficer)
        {
            ServiceResponse<Officer> serviceResponse = new ServiceResponse<Officer>();
            try
            {
                await _context.AddAsync(newOfficer);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newOfficer;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> DeleteOfficer(int id)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            try
            {
                int initialRecords = await _context.Officers.CountAsync();
                var officer = await _context.Officers.FirstOrDefaultAsync(p => p.Id == id);
                _context.Remove(officer);
                await _context.SaveChangesAsync();
                int existingRecords = await _context.Officers.CountAsync();
                serviceResponse.Data = existingRecords - initialRecords;

            }
            catch (Exception ex)
            {

                serviceResponse.Data = 0;
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Officer>> GetOfficer(int id)
        {
            ServiceResponse<Officer> serviceResponse = new ServiceResponse<Officer>();
            try
            {
                serviceResponse.Data = await _context.Officers.FirstOrDefaultAsync(p => p.Id == id);

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<Officer>> UpdateOfficer(Officer updatedOfficer)
        {
            ServiceResponse<Officer> serviceResponse = new ServiceResponse<Officer>();
            try
            {

                _context.Entry(updatedOfficer).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                serviceResponse.Data = updatedOfficer;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}
