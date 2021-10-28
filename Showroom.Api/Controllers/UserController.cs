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
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;

        public UserController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userRepository.GetUsers());
            }
            catch (Exception)
            {
                Console.WriteLine("Couldnt get users");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            try
            {
                return Ok(await _userRepository.GetUser(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                else
                {
                    var userFound = await _userRepository.GetUserByEmail(user.Email);

                    if (userFound != null)
                    {
                        ModelState.AddModelError("email", "User email already in use");
                        return BadRequest(ModelState);
                    }

                    var createdEmployee = await _userRepository.AddUser(user);

                    return CreatedAtAction(nameof(GetUser), new {id = createdEmployee.UserId}, createdEmployee);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            try
            {
                if (id != user.UserId)
                {
                    return BadRequest("User id missmatch!");
                }

                var userToUpdate = await _userRepository.GetUser(id);

                if (userToUpdate == null)
                {
                    return NotFound($"User with {id} id not found");
                }

                return await _userRepository.UpdateUser(id, user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var userToDelete = await _userRepository.GetUser(id);

            if (userToDelete == null)
            {
                return NotFound($"User with id {id} not fou");
            }

            try
            {
                return Ok(await _userRepository.DeleteUser(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
