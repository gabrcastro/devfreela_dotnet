using DevFreelaAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaAPI.Controllers {

    [Route("api/users")]
    public class UsersController : ControllerBase {

        [HttpGet]
        public IActionResult GetAll() {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id) {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel user) {
            if (user.Name.Length < 3) {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetOne), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserModel user) {
            if (user.Name.Length < 3 || user.Email.Length <= 0 || user.Ocupation.Length <= 0) {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("{id}/login")]
        public IActionResult Delete(int id, [FromBody] LoginUserModel user) {
            return NoContent();
        }
    }
}
