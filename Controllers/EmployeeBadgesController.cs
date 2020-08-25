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
    public class EmployeeBadgesController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public EmployeeBadgesController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeBadges
        [HttpGet]
        public IEnumerable<EmployeeBadges> GetEmployeeBadges()
        {
            return _context.EmployeeBadges;
        }

        // GET: api/EmployeeBadges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeBadges([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeBadges = await _context.EmployeeBadges.FindAsync(id);

            if (employeeBadges == null)
            {
                return NotFound();
            }

            return Ok(employeeBadges);
        }

    }
}