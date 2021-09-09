using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<UserModel> users = new List<UserModel>();

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = users.FirstOrDefault(t => t.UserId == id);

            if (user == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(user);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel value)
        {
            if (value == null)
            {
                return BadRequest(new { error  = "Missing request body" });
            }

            if (value.UserEmail == null)
            {
                return BadRequest(new { error = "Missing user email" });
            }

            if (value.UserPassword == null)
            {
                return BadRequest(new { error = "Missing user password" });
            }

            value.UserId = Guid.NewGuid();
            value.UserCreateDate = DateTime.Now;
            users.Add(value);

            return CreatedAtAction(nameof(Post), new { id = value.UserId }, value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UserModel value)
        {
            var user = users.FirstOrDefault(t => t.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            if (value.UserPassword != null)
            {
                user.UserEmail = value.UserEmail;
            }

            if (value.UserPassword != null)
            {
                user.UserPassword = value.UserPassword;
            }

            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deletedUser = users.RemoveAll(t => t.UserId == id);

            if (deletedUser == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
