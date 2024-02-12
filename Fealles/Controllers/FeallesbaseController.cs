using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fealles.Models;
using Fealles.Data;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FeallesService.Models;
using AutoMapper;

namespace FeallesService.Controllers
{

    
    [Route("api/feallesbase")]
    [ApiController]
    [Authorize]
    public class FeallesbaseController : ControllerBase

    {


        private readonly AppDbContext _db;
        private Response _response;
        private IMapper _mapper;
        public FeallesbaseController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new Response();

        }

        // GET: api/Feallesbase
        [HttpGet]
        public  Response GetFeallesbases()
        {
            try
            {
                IEnumerable<Feallesbase> objList = _db.Feallesbases.ToList();
                _response.Result = _mapper.Map<IEnumerable<Feallesbase>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

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


