using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocjaController : Controller
    {
        s16693Context _context;
        public PromocjaController(s16693Context context)
        {

            _context = context;

        }

        [HttpGet]
        public IActionResult GetPromocjas()
        {

            return Ok(_context.Promocja.ToList());

        }

        [HttpGet("{id:int}")]
        public IActionResult GetPromocja(DateTime dt)
        {

            var emp = _context.Promocja.FirstOrDefault(e => e.OdKiedy == dt);

            if (emp == null)
            {

                return NotFound();

            }

            return Ok(emp);

        }

    }
}
