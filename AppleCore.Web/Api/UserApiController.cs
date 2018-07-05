using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppleCore.Web.Api
{
    [Route("api/users")]
    public class UserApiController : ControllerBase
    {
        // GET: api/users

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Joe Bloggs", "Jill Bloggs", "Freddie Cougar", "Billy Bob" };
        }

        // GET: api/users/5

        [HttpGet("{id}")]
        public string Get(
            int id)
        {
            return "A Value Stored in the API controller";
        }

        // POST: api/users

        [HttpPost]
        public void Post(
            [FromBody] string value)
        {
        }

        // PUT: api/users/5

        [HttpPut("{id}")]
        public void Put(
            int id, 
            [FromBody] string value)
        {
        }

        // DELETE: api/users/5

        [HttpDelete("{id}")]
        public void Delete(
            int id)
        {
        }
    }
}
