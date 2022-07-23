using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendServer.DataBase;
using BackendServer.Models;
using Microsoft.AspNetCore.Authorization;

namespace BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.Admin)]
    public class StudentiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Studenti
        [HttpGet]
        public List<StudentiModel> GetStudenti()
        {

            var lista = from student in _context.Studenti
                        where student.ProsjekOcjena > 9
                        select student;

            return lista.ToList();

            /*
            var lista = _context.Studenti.Where(student => student.ProsjekOcjena > 9).ToList();

            return lista;*/
        }


        [HttpGet]
        [Route("ProsjekOcjena/{prosjek}")]
        public IActionResult GestProsjekOcjena(int prosjek)
        {
            // s = student skracenica
            var lista = _context.Studenti.Where(s => s.ProsjekOcjena >= prosjek).ToList();

            return Ok(lista);
        }

        [HttpGet]
        [Route("Prezime/{prezime}")]
        public IActionResult FilterPrezime(string prezime)
        {
            var lista = _context.Studenti.Where(s => s.Ime.Equals("fatima"));

            return Ok(lista);
        }

        [HttpGet]
        [Route("Average")]
        public IActionResult UkupniProsjek()
        {

            var UkupniProsjek = _context.Studenti.Average(s => s.ProsjekOcjena);

            var minOcjena = _context.Studenti.Min(s => s.ProsjekOcjena);

            var maxOcjena = _context.Studenti.Max(s => s.ProsjekOcjena);

            return Ok(UkupniProsjek);
        }



        // GET: api/Studenti/Informatika
        [HttpGet]
        [Route("Informatika")]
        public IActionResult GetInformatika()
        {
            var listaStudenataInformatike = _context.Studenti.Where(student => student.Smjer == "Informatika").ToList();



            return Ok(listaStudenataInformatike);
        }

        // GET: api/Studenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentiModel>> GetStudentiModel(int id)
        {
            var studentiModel = await _context.Studenti.FindAsync(id);

            if (studentiModel == null)
            {
                return NotFound();
            }

            return studentiModel;
        }

        // PUT: api/Studenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentiModel(int id, StudentiModel studentiModel)
        {
            if (id != studentiModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(studentiModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentiModelExists(id))
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

        // POST: api/Studenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentiModel>> PostStudentiModel(StudentiModel studentiModel)
        {
            _context.Studenti.Add(studentiModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentiModel", new { id = studentiModel.ID }, studentiModel);
        }

        // DELETE: api/Studenti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentiModel(int id)
        {
            var studentiModel = await _context.Studenti.FindAsync(id);
            if (studentiModel == null)
            {
                return NotFound();
            }

            _context.Studenti.Remove(studentiModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentiModelExists(int id)
        {
            return _context.Studenti.Any(e => e.ID == id);
        }
    }
}
