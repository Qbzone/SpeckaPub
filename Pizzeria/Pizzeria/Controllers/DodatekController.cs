using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DodatekController : ControllerBase
    {

        s16693Context _context;
        public DodatekController(s16693Context context)
        {

            _context = context;

        }

        [HttpGet]
        public IActionResult GetDodateks()
        {

            return Ok(_context.Dodatek.ToList());

        }

        [HttpGet("{id:int}")]
        public IActionResult GetDodatek(int id)
        {

            var emp = _context.Dodatek.FirstOrDefault(e => e.IdProdukt == id);

            if (emp == null)
            {

                return NotFound();

            }

            return Ok(emp);

        }

        [HttpPost]
        public IActionResult PostDodatek(Dodatek newDodatek)
        {

            _context.Dodatek.Add(newDodatek);
            _context.SaveChanges();

            return StatusCode(201, newDodatek);

        }

        [HttpPut]
        public IActionResult PutDodatek(Dodatek updatedDodatek)
        {

            if (_context.Dodatek.Count(e => e.IdProdukt == updatedDodatek.IdProdukt) == 0)
            {

                return NotFound();

            }

            _context.Dodatek.Attach(updatedDodatek);
            _context.Entry(updatedDodatek).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedDodatek);

        }

        [HttpDelete("{IdProdukt:int}")]
        public IActionResult DeleteDodatek(int IdProdukt)
        {

            var prod = _context.Dodatek.FirstOrDefault(e => e.IdProdukt == IdProdukt);

            if (prod == null)
            {

                return NotFound();

            }

            _context.Dodatek.Remove(prod);
            _context.SaveChanges();

            return Ok(prod);

        }

    }
}