namespace Showroom.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Showroom.Api.Models;
    using Showroom.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _projectRepository.GetProjects());
            }
            catch (Exception)
            {
                Console.WriteLine("Couldnt get users");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProject(int id)
        {
            try
            {
                return Ok(await _projectRepository.GetProject(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createProject = await _projectRepository.AddProject(project);

                    return CreatedAtAction(nameof(GetProject), new {id = createProject.Id}, createProject);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project project)
        {
            try
            {
                if (id != project.Id)
                {
                    return BadRequest("User id missmatch!");
                }

                var projectToUpdate = await _projectRepository.GetProject(id);

                if (projectToUpdate == null)
                {
                    return NotFound($"Project with {id} id not found");
                }

                return await _projectRepository.UpdateProject(id, project);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<User>> DeleteUser(int id)
        //{
        //    var userToDelete = await _projectRepository.GetUser(id);

        //    if (userToDelete == null)
        //    {
        //        return NotFound($"User with id {id} not fou");
        //    }

        //    try
        //    {
        //        return Ok(await _projectRepository.DeleteUser(id));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}
    }
}
