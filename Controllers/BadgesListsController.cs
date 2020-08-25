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

        // PUT: api/BadgesLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBadgesList([FromRoute] int id, [FromBody] BadgesList badgesList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != badgesList.BadgeId)
            {
                return BadRequest();
            }

            _context.Entry(badgesList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadgesListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BadgesLists
        [HttpPost]
        public async Task<IActionResult> PostBadgesList([FromBody] BadgesList badgesList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BadgesList.Add(badgesList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BadgesListExists(badgesList.BadgeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBadgesList", new { id = badgesList.BadgeId }, badgesList);
        }

        // DELETE: api/BadgesLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBadgesList([FromRoute] int id)
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

            _context.BadgesList.Remove(badgesList);
            await _context.SaveChangesAsync();

            return Ok(badgesList);
        }

        private bool BadgesListExists(int id)
        {
            return _context.BadgesList.Any(e => e.BadgeId == id);
        }
    }
}