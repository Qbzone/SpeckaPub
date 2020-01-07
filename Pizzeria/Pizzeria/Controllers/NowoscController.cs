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
    public class NowowscController : ControllerBase
    {

        s16693Context _context;
        public NowowscController(s16693Context context)
        {

            _context = context;

        }

        [HttpGet]
        public IActionResult GetNowoscs()
        {

            return Ok(_context.Nowosc.ToList());

        }

        [HttpGet("{id:int}")]
        public IActionResult GetNowosc(DateTime dt)
        {

            var emp = _context.Nowosc.FirstOrDefault(e => e.OdKiedy == dt);

            if (emp == null)
            {

                return NotFound();

            }

            return Ok(emp);

        }

    }
}