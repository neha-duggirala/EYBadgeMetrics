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
    public class ClientSatisfactionReviewsController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public ClientSatisfactionReviewsController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/ClientSatisfactionReviews
        [HttpGet]
        public IEnumerable<ClientSatisfactionReview> GetClientSatisfactionReview()
        {
            return _context.ClientSatisfactionReview;
        }

        // GET: api/ClientSatisfactionReviews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientSatisfactionReview([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientSatisfactionReview = await _context.ClientSatisfactionReview.FindAsync(id);

            if (clientSatisfactionReview == null)
            {
                return NotFound();
            }

            return Ok(clientSatisfactionReview);
        }

    }
}