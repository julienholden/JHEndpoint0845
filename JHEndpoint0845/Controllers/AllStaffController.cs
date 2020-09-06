using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JHEndpoint0845.Models;

namespace JHEndpoint0845.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllStaffController : ControllerBase
    {
        private readonly JHDbaseContext _context;

        public AllStaffController(JHDbaseContext context)
        {
            _context = context;
        }

        // GET: api/AllStaff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllStaff>>> GetAllStaff()
        {
            //return await _context.AllStaff.ToListAsync();
            return Ok(await _context.AllStaff.OrderByDescending(i => i.Ytdsales).ToListAsync());
        }

        // GET: api/AllStaff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllStaff>> GetAllStaff(int id)
        {
            var allStaff = await _context.AllStaff.FindAsync(id);

            if (allStaff == null)
            {
                return NotFound();
            }

            return allStaff;
        }

        // PUT: api/AllStaff/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllStaff(int id, AllStaff allStaff)
        {
            if (id != allStaff.Id)
            {
                return BadRequest();
            }

            _context.Entry(allStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllStaffExists(id))
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

        // POST: api/AllStaff
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AllStaff>> PostAllStaff(AllStaff allStaff)
        {
            _context.AllStaff.Add(allStaff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllStaff", new { id = allStaff.Id }, allStaff);
        }

        // DELETE: api/AllStaff/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AllStaff>> DeleteAllStaff(int id)
        {
            var allStaff = await _context.AllStaff.FindAsync(id);
            if (allStaff == null)
            {
                return NotFound();
            }

            _context.AllStaff.Remove(allStaff);
            await _context.SaveChangesAsync();

            return allStaff;
        }

        private bool AllStaffExists(int id)
        {
            return _context.AllStaff.Any(e => e.Id == id);
        }
    }
}
