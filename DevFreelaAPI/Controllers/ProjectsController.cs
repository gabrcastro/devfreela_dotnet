using DevDreela.Application.InputModels;
using DevDreela.Application.Services.Interfaces;
using DevFreelaAPI.Models;
using DevFreelaAPI.Models.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreelaAPI.Controllers
{
    [Route("apit/projecs")]
    public class ProjectsController : ControllerBase {

        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService) {
            _projectService = projectService;    
        }
    
        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            var project = _projectService.GetOne(id);
            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length < 3 || inputModel.Title.Length > 50) return BadRequest();

            var id = _projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjecInputtModel inputModel) {
            if (inputModel.Description.Length < 3 || inputModel.Description.Length > 50) return BadRequest();

            _projectService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _projectService.Delete(id);
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment([FromBody] CreateCommentInputModel inputModel) {
            _projectService.CreateComment(inputModel);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult UpdateStart(int id) {
            _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult UpdateFinish(int id) {
            _projectService.Finish(id);

            return NoContent();
        }

        
    }
}
