using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneSite.Data;

namespace PhoneSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase //дає доступ до http responses , а також до IActionResult
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        public IActionResult GetValues()
        {
            var values = _context.MyProperty.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = _context.MyProperty.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
