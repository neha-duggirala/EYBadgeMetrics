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
    public class BadgesListsController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public BadgesListsController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/BadgesLists
        [HttpGet]
        public IEnumerable<BadgesList> GetBadgesList()
        {
            return _context.BadgesList;
        }

        // GET: api/BadgesLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBadgesList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var badgesList = await _context.BadgesList.FindAsync(id);

            if (badgesList == null)
            {
                return NotFound();
            }

            return Ok(badgesList);
        }

     
    }
}