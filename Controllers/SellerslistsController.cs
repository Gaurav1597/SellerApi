using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellerApi.Data;
using SellerApi.Models;

namespace SellerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerslistsController : ControllerBase
    {
        private readonly SellerApiContext _context;

        public SellerslistsController(SellerApiContext context)
        {
            _context = context;
        }

        // GET: api/Sellerslists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sellerslist>>> GetSellerslist()
        {
            return await _context.Sellerslist.ToListAsync();
        }

        // GET: api/Sellerslists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sellerslist>> GetSellerslist(int id)
        {
            var sellerslist = await _context.Sellerslist.FindAsync(id);

            if (sellerslist == null)
            {
                return NotFound();
            }

            return sellerslist;
        }

        // PUT: api/Sellerslists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellerslist(int id, Sellerslist sellerslist)
        {
            if (id != sellerslist.id)
            {
                return BadRequest();
            }

            _context.Entry(sellerslist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerslistExists(id))
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

        // POST: api/Sellerslists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sellerslist>> PostSellerslist(Sellerslist sellerslist)
        {
            _context.Sellerslist.Add(sellerslist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSellerslist", new { id = sellerslist.id }, sellerslist);
        }

        // DELETE: api/Sellerslists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellerslist(int id)
        {
            var sellerslist = await _context.Sellerslist.FindAsync(id);
            if (sellerslist == null)
            {
                return NotFound();
            }

            _context.Sellerslist.Remove(sellerslist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellerslistExists(int id)
        {
            return _context.Sellerslist.Any(e => e.id == id);
        }
    }
}
