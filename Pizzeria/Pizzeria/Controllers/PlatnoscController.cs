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
    public class PlatnoscController : ControllerBase
    {

        s16693Context _context;
        public PlatnoscController(s16693Context context)
        {

            _context = context;

        }

        [HttpGet]
        public IActionResult GetPlatnoscs()
        {

            return Ok(_context.Platnosc.ToList());

        }

        [HttpGet("{id:int}")]
        public IActionResult GetPlatnosc(string name)
        {

            var emp = _context.Platnosc.FirstOrDefault(e => e.Nazwa == name);

            if (emp == null)
            {

                return NotFound();

            }

            return Ok(emp);

        }

        [HttpPost]
        public IActionResult PostPlatnosc(Platnosc newPlatnosc)
        {

            _context.Platnosc.Add(newPlatnosc);
            _context.SaveChanges();

            return StatusCode(201, newPlatnosc);

        }

        [HttpPut]
        public IActionResult PutPizza(Platnosc updatedPlatnosc)
        {

            if (_context.Platnosc.Count(e => e.IdPlatnosc == updatedPlatnosc.IdPlatnosc) == 0)
            {

                return NotFound();

            }

            _context.Platnosc.Attach(updatedPlatnosc);
            _context.Entry(updatedPlatnosc).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPlatnosc);

        }

        [HttpDelete("{IdProdukt:int}")]
        public IActionResult DeletePizza(int idPlatnosc)
        {

            var prod = _context.Platnosc.FirstOrDefault(e => e.IdPlatnosc == idPlatnosc);

            if (prod == null)
            {

                return NotFound();

            }

            _context.Platnosc.Remove(prod);
            _context.SaveChanges();

            return Ok(prod);

        }

    }
}