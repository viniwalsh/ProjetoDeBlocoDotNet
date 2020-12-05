using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBloco.Domain.Model.Entities;
using WEBloco.Domain.Model.Interfaces;

namespace WEBlocoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IHeroiService _service;
        private readonly IBlobService _blobService;

        public HeroiController(IHeroiService service, IBlobService blobService)
        {
            _service = service;
            _blobService = blobService;
        }

        // GET: api/Heroi
        [HttpGet]
        [ProducesResponseType(typeof(Heroi), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Heroi>>> GetHeroi()
        {
            var herois = (await _service.GetAllAsync()).ToList();
            return herois;
        }

        // GET: api/Heroi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Heroi>> GetHeroi(int id)
        {
            var heroi = await _service.GetByIdAsync(id);

            if (heroi == null)
            {
                return NotFound();
            }

            return heroi;
        }

        // POST: api/Heroi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Heroi>> PostHeroi(Heroi heroi)
        {
            try
            {
                await _service.InsertAsync(heroi);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction(nameof(GetHeroi), new { id = heroi.HeroiId }, heroi);
        }
    }
}
