using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EYBadges.Models;

namespace EYBadges.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public ModulesController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet]
        public IEnumerable<Modules> GetModules()
        {
            return _context.Modules;
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModules([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modules = await _context.Modules.FindAsync(id);

            if (modules == null)
            {
                return NotFound();
            }

            return Ok(modules);
        }

    }
}