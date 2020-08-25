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
    public class DeveloperKpisController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public DeveloperKpisController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/DeveloperKpis
        [HttpGet]
        public IEnumerable<DeveloperKpi> GetDeveloperKpi()
        {
            return _context.DeveloperKpi;
        }

        // GET: api/DeveloperKpis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloperKpi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developerKpi = await _context.DeveloperKpi.FindAsync(id);

            if (developerKpi == null)
            {
                return NotFound();
            }

            return Ok(developerKpi);
        }

    }
}