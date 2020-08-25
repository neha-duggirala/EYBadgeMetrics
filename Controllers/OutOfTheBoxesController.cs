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
    public class OutOfTheBoxesController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public OutOfTheBoxesController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/OutOfTheBoxes
        [HttpGet]
        public IEnumerable<OutOfTheBox> GetOutOfTheBox()
        {
            return _context.OutOfTheBox;
        }

        // GET: api/OutOfTheBoxes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOutOfTheBox([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var outOfTheBox = await _context.OutOfTheBox.FindAsync(id);

            if (outOfTheBox == null)
            {
                return NotFound();
            }

            return Ok(outOfTheBox);
        }
    }
}