using DevFreelaAPI.Models;
using DevFreelaAPI.Models.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreelaAPI.Controllers
{
    [Route("apit/projecs")]
    public class ProjectsController : ControllerBase {
        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass) {
            exampleClass.Name = "Updated at ProjectsController";
            _option = option.Value;
        }
    
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProjectModel project)
        {
            if (project.Title.Length < 3)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetOne), new { id = project.Id }, project);
        }

        [HttpPost("{id}/comments")]
        public IActionResult CreateComment([FromBody] CreateCommentModel project) {
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProjectModel project)
        {
            if (project.Title.Length < 3)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult UpdateStart(int id, [FromBody] UpdateProjectModel project) {
            if (project.Title.Length < 3) {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult UpdateFinish(int id, [FromBody] UpdateProjectModel project) {
            if (project.Title.Length < 3) {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
