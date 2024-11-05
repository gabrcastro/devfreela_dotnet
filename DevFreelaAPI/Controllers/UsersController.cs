using DevDreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreelaAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaAPI.Controllers {

    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IActionResult Get(string query)
        {
            var users = _userService.GetAll(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewUserInputModel inputModel) {
            if (inputModel.FullName.Length < 3) {
                return BadRequest();
            }

            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id}, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserModel user) {
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
