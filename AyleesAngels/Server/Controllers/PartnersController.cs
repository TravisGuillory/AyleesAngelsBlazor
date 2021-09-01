using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AyleesAngels.Server.Data;
using Microsoft.AspNetCore.Authorization;
using AyleesAngels.Shared.Models;
using AyleesAngels.Server.Services;
using AyleesAngels.Shared.Utils;

namespace AyleesAngels.Server.Controllers
{
    
    public class PartnersController : Controller
    {

        private readonly IPartnerService _partnerService;
        


        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;

        }

        // GET: api/Partners
        [HttpGet(Urls.Partners)]
        [AllowAnonymous]
        public async Task<IActionResult> GetPartners()
        {

            var response = await _partnerService.GetPartners();
            return Ok(response);

        }


        // GET: api/Partners/5
        [HttpGet(Urls.Partner)]
        [AllowAnonymous]
        public async Task<IActionResult> GetPartner(int id)
        {
            var partner = await _partnerService.GetPartner(id);

            if (partner == null)
            {
                return NotFound();
            }

            return Ok(partner);
        }

        // POST: api/Partners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost(Urls.AddPartner)]
        public async Task<IActionResult> PostPartner([FromBody] Partner newPartner)
        {
            await _partnerService.AddPartner(newPartner);


            return CreatedAtAction("GetPartner", new { id = newPartner.Id }, newPartner);
        }

        // PUT: api/Partners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut(Urls.UpdatePartner)] 
        public async Task<IActionResult> PutPartner(int id,[FromBody] Partner updatedPartner)
        {
            await _partnerService.UpdatePartner(updatedPartner);

            return Ok(updatedPartner);
        }

        // DELETE: api/Partners/5
        [Authorize]
        [HttpDelete(Urls.DeletePartner)]
        public async Task<IActionResult> DeletePartner(int id)
        {
            var partner = await _partnerService.DeletePartner(id);

            return Ok();
        }


    }
}