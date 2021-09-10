using AyleesAngels.Server.Data;
using AyleesAngels.Server.Services;
using AyleesAngels.Shared.Models;
using AyleesAngels.Shared.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyleesAngels.Server.Controllers
{


    public class OfficersController : ControllerBase
    {
        private readonly OfficerDbContext _context;
        private readonly IOfficerService _service;

        public OfficersController(IOfficerService service, OfficerDbContext context)
        {
            _context = context;
            _service = service;
        }

        [HttpGet(Urls.Officers)]
        [AllowAnonymous]
        public async Task<IActionResult> Officers()
        {

            try
            {
                return Ok(await _service.GetOfficers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet(Urls.Officer)]
        [AllowAnonymous]
        public async Task<IActionResult> Officer(int id)
        {
            try
            {
                return Ok(await _service.GetOfficer(id));
                
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost(Urls.AddOfficer)]
        [Authorize]
        public async Task<IActionResult> AddOfficer([FromBody] Officer newOfficer)
        {
            try
            {
                await _service.AddOfficer(newOfficer);
                
                return CreatedAtAction("Officer", new { id = newOfficer.Id }, newOfficer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Urls.UpdateOfficer)]
        [Authorize]
        public async Task<IActionResult> UpdateOfficer(int id, [FromBody] Officer updatedOfficer)
        {
            try
            {
                await _service.UpdateOfficer(updatedOfficer);
                return Ok(updatedOfficer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Urls.DeleteOfficer)]
        [Authorize]
        public async Task<IActionResult> DeleteOfficer(int id)
        {
            int initialRecords = await _context.Officers.CountAsync();
            var partner = await _context.Officers.FirstOrDefaultAsync(o => o.Id == id);
            _context.Remove(partner);
            await _context.SaveChangesAsync();
            int currentRecords = await _context.Officers.CountAsync();
            return Ok(initialRecords - currentRecords);
        }
    
    }
}
