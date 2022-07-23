using BackendServer.DataBase;
using BackendServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackendServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrviController : ControllerBase
    {
        private ILog _logiranje;
        private ApplicationDbContext _context;

        public PrviController(ILog logiranje, ApplicationDbContext context)
        {
            _logiranje = logiranje;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logiranje.Informacija();

            var lista = new List<string>();

            var listaOsoba = new List<OsobaModel>();

            var alen = new OsobaModel();

            alen.Prezime = "Lovic";
            alen.Ime = "Alen";

            var bosko = new OsobaModel
            {
                Prezime = "Tepacevic", Ime = "Bosko"
            };

            var fatima = new OsobaModel { Prezime = "Jasarevic", Ime = "Fatima" };

            var darija = new OsobaModel { Prezime = "Jolic", Ime = "Darija" };

            var marina = new OsobaModel { Prezime = "orezime", Ime = "ime"};

            listaOsoba.Add(alen);
            listaOsoba.Add(bosko);
            listaOsoba.Add(fatima);
            listaOsoba.Add(darija);




            try 
            {
                return Ok(listaOsoba);
            }
            catch
            {
                var greska = "gresk1";
                return Problem(detail: greska);
            }
        }

        [HttpPost]
        public IActionResult Post(OsobaModel osoba) 
        {

            _context.Osobe.Add(osoba);
            _context.SaveChanges();


        return Ok();               
        }



    }
}
