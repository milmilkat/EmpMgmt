using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpMgmt.Models;

namespace EmpMgmt.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpsController : ControllerBase
    {
        private readonly EmpMgmtContext _context;

        public EmpsController(EmpMgmtContext context)
        {
            _context = context;
        }

        // GET: api/Emps
        [Route("~/api/GetEmp")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emp>>> GetEmp()
        {
            return await _context.Emp.ToListAsync();
        }

        // GET: api/Emps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emp>> GetEmp(int id)
        {
            var emp = await _context.Emp.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        // PUT: api/Emps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmp(int id, Emp emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }

            _context.Entry(emp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpExists(id))
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

        [Route("~/api/UpdateEmp")]
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody]Emp emp)
        {
            _context.Update(emp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmp", new { id = emp.Id }, emp);

        }

        // POST: api/Emps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Route("~/api/AddEmp")]
        [HttpPost]
        public async Task<ActionResult<Emp>> PostEmp(Emp emp)
        {
            _context.Emp.Add(emp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmp", new { id = emp.Id }, emp);
        }

        // DELETE: api/Emps/5
        [Route("~/api/DeleteEmp/{id}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Emp>> DeleteEmp(int id)
        {
            var emp = await _context.Emp.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            _context.Emp.Remove(emp);
            await _context.SaveChangesAsync();

            return emp;
        }

        private bool EmpExists(int id)
        {
            return _context.Emp.Any(e => e.Id == id);
        }
    }
}
