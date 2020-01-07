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
    public class PizzaController : Controller
    {
        private s16693Context _context;

        public PizzaController(s16693Context context)
        {

            _context = context;

        }

        [HttpGet]
        public IActionResult GetPizzas()
        {

            return Ok(_context.Pizza.ToList());

        }

        [HttpGet("{id=int}")]
        public IActionResult GetPizza(int id)
        {

            var emp = _context.Pizza.FirstOrDefault(e => e.IdProdukt == id);

            if (emp == null)
            {

                return NotFound();

            }

            return Ok(emp);

        }

        [HttpPost]
        public IActionResult PostPizza(Pizza newPizza)
        {

            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);

        }

        [HttpPut]
        public IActionResult PutPizza(Pizza updatedPizza)
        {

            if (_context.Pizza.Count(e => e.IdProdukt == updatedPizza.IdProdukt) == 0)
            {

                return NotFound();

            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);

        }

        [HttpDelete("{IdProdukt:int}")]
        public IActionResult DeletePizza(int IdProdukt)
        {

            var prod = _context.Pizza.FirstOrDefault(e => e.IdProdukt == IdProdukt);

            if(prod == null)
            {

                return NotFound();

            }

            _context.Pizza.Remove(prod);
            _context.SaveChanges();

            return Ok(prod);

        }

    }

}