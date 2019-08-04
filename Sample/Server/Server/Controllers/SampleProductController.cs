using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleProductController : ControllerBase
    {
        private readonly Dictionary<Guid, string> _inMemoryStore = new Dictionary<Guid, string>();

        // GET api/sampleproduct
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _inMemoryStore.Values;
        }

        // GET api/sampleproduct/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            return _inMemoryStore[id];
        }

        // POST api/sampleproduct
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _inMemoryStore[Guid.NewGuid()] = value;
        }

        // PUT api/sampleproduct/00000000-0000-0000-0000-000000000000
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
            _inMemoryStore[id] = value;
        }

        // DELETE api/sampleproduct/00000000-0000-0000-0000-000000000000
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _inMemoryStore.Remove(id);
        }
    }
}
