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
        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<IActionResult> PostPartner(Partner partner)
        {
            await _partnerService.AddPartner(partner);


            return CreatedAtAction("GetPartner", new { id = partner.Id }, partner);
        }

        // PUT: api/Partners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartner(int id, Partner updatedPartner)
        {
            await _partnerService.UpdatePartner(updatedPartner);

            return Ok(updatedPartner);
        }

        // DELETE: api/Partners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartner(int id)
        {
            var partner = await _partnerService.DeletePartner(id);

            return Ok();
        }


    }
}