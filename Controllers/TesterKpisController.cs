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
    public class TesterKpisController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public TesterKpisController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/TesterKpis
        [HttpGet]
        public IEnumerable<TesterKpi> GetTesterKpi()
        {
            return _context.TesterKpi;
        }

        // GET: api/TesterKpis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTesterKpi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testerKpi = await _context.TesterKpi.FindAsync(id);

            if (testerKpi == null)
            {
                return NotFound();
            }

            return Ok(testerKpi);
        }

    }
}