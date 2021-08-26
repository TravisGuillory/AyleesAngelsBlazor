using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyleesAngels.Server.Data;
using AyleesAngels.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AyleesAngels.Server.Services
{
    public class PartnerService : IPartnerService
    {
        private PartnerDbContext _context { get; set; }

        public PartnerService(PartnerDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Partner>> AddPartner(Partner newPartner)
        {

            ServiceResponse<Partner> serviceResponse = new ServiceResponse<Partner>();
            try
            {
                await _context.Partners.AddAsync(newPartner);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newPartner;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;            
        }

        public async Task<ServiceResponse<int>> DeletePartner(int id)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            try
            {
                int initialRecords = await _context.Partners.CountAsync();
                var blogPost = await _context.Partners.FirstOrDefaultAsync(p => p.Id == id);
                _context.Remove(blogPost);
                await _context.SaveChangesAsync();
                int existingRecords = await _context.Partners.CountAsync();
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

        public async Task<ServiceResponse<Partner>> GetPartner(int id)
        {
            ServiceResponse<Partner> serviceResponse = new ServiceResponse<Partner>();
            try
            {
                serviceResponse.Data = await _context.Partners.FirstOrDefaultAsync(p => p.Id == id);

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse; 
        }

        public async Task<ServiceResponse<List<Partner>>> GetPartners()
        {
            ServiceResponse<List<Partner>> serviceResponse = new ServiceResponse<List<Partner>>();
            serviceResponse.Data = await _context.Partners.ToListAsync();
            return serviceResponse;
        }

        

        public async Task<ServiceResponse<Partner>> UpdatePartner(Partner updatedPartner)
        {
            ServiceResponse<Partner> serviceResponse = new ServiceResponse<Partner>();
            try
            {
                
                _context.Entry(updatedPartner).State = EntityState.Modified;
                
                await _context.SaveChangesAsync();
                serviceResponse.Data = updatedPartner;
                
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
