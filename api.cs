using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockBeheer.Data;
using StockBeheer.Models;

namespace StockBeheer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockLogsController : ControllerBase
    {
        private readonly ProWebshop2021StockCOntextV2 _context;

        public StockLogsController(ProWebshop2021StockCOntextV2 context)
        {
            _context = context;
        }

        // GET: api/StockLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockLog>>> GetStockLog()
        {
            return await _context.StockLog.ToListAsync();
        }

        // GET: api/StockLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockLog>> GetStockLog(int id)
        {
            var stockLog = await _context.StockLog.FindAsync(id);

            if (stockLog == null)
            {
                return NotFound();
            }

            return stockLog;
        }

        // PUT: api/StockLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockLog(int id, StockLog stockLog)
        {
            if (id != stockLog.id)
            {
                return BadRequest();
            }

            _context.Entry(stockLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockLogExists(id))
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

        // POST: api/StockLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StockLog>> PostStockLog(StockLog stockLog)
        {
            _context.StockLog.Add(stockLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockLog", new { id = stockLog.id }, stockLog);
        }

        // DELETE: api/StockLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockLog>> DeleteStockLog(int id)
        {
            var stockLog = await _context.StockLog.FindAsync(id);
            if (stockLog == null)
            {
                return NotFound();
            }

            _context.StockLog.Remove(stockLog);
            await _context.SaveChangesAsync();

            return stockLog;
        }

        private bool StockLogExists(int id)
        {
            return _context.StockLog.Any(e => e.id == id);
        }
    }
}
