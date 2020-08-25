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
    public class TeamDetailsController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public TeamDetailsController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/TeamDetails
        [HttpGet]
        public IEnumerable<TeamDetails> GetTeamDetails()
        {
            return _context.TeamDetails;
        }

        // GET: api/TeamDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamDetails = await _context.TeamDetails.FindAsync(id);

            if (teamDetails == null)
            {
                return NotFound();
            }

            return Ok(teamDetails);
        }

    }
}