using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeallesBase.Models;
using FeallesBase.Data;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace FeallesBase.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FeallesbaseController : ControllerBase

    {


        private readonly AppDbContext _db;

        public FeallesbaseController(AppDbContext db)
        {
            _db = db;

        }

        // GET: api/Feallesbase
        [HttpGet]
        public async Task<ActionResult> GetFeallesbases()
        {

            try
            {
                var objList = from b in await _db.Feallesbases.ToListAsync() select b;

                // Process 'data' or return it as needed
                return Ok(objList); // Return HTTP 200 OK with the 'data'


            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal Server Error");
            }

        }


            // GET: api/Feallesbase/5
            [HttpGet("{id}")]
        public async Task<ActionResult<Feallesbase>> GetFeallesbase(int id)
        {
            var feallesbase = await _db.Feallesbases.FindAsync(id);

            if (feallesbase == null)
            {
                return NotFound();
            }

            return feallesbase;
        }

        // POST: api/Feallesbase
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Feallesbase feallesbase)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _db.Feallesbases.AddAsync(feallesbase);
                    await _db.SaveChangesAsync();
                    return Ok(200);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    return BadRequest("Failed to create the resource: " + ex.Message);
                }
            }
            return BadRequest();

        }
        // PUT: api/Feallesbase/5
        [HttpPut("{ID}")]
        public async Task<IActionResult> PutFeallesbase( int ID, [FromBody] Feallesbase feallesbase)
        {
            Console.WriteLine($"Received ID: {ID}, Feallesbase: {JsonConvert.SerializeObject(feallesbase)}");

            if (ID != feallesbase.ID)
            {
                // Log the mismatch for debugging
                Console.WriteLine("ID mismatch");
                return BadRequest();
            }

            _db.Entry(feallesbase).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeallesbaseExists(ID))
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

        // DELETE: api/Feallesbase/5
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteFeallesbase(int? ID)
        {
            var feallesbase = await _db.Feallesbases.FindAsync(ID);
            if (feallesbase == null)
            {
                return NotFound();
            }

            _db.Feallesbases.Remove(feallesbase);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool FeallesbaseExists(int id)
        {
            return _db.Feallesbases.Any(e => e.ID == id);
        }

    }
}


