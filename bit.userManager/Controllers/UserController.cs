using bit.userManager.IRepository;
using bit.userManager.Models;
using bit.userManager.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace bit.userManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase 
    {
        private static List<user> users = new List<user>
        {
            new user { Id = 1, FullName = "Test", Email = "test@example.com", Password = "password" }
        };
        private readonly MyDbContext _dbContext;
        private readonly IUser _userService;
        private readonly UserServiceClass _UserServiceClass;
        public UserController(IUser userService, UserServiceClass UserServiceClass, MyDbContext cont)
        {
            _userService = userService;
            _UserServiceClass = UserServiceClass;
            _dbContext = cont;
        }

        [HttpGet("add-number")]
        public IActionResult AddNumber()
        {
            return Ok(_userService.addNumber());
        }

        [HttpGet("get-NAME")]
        public IActionResult gertUserFronDb()
        {
            var users = _dbContext.Users.ToList();   
            return Ok(users);
        }

        [HttpPost("add-user")]
        public IActionResult AddUser([FromBody] user user)
        {
            return Ok(_userService.CreateUser(user));
        }

        // GET: api/User/get-user/{id}
        [HttpGet("get-user/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userService.getUserId(id));
        }

        // POST: api/User/create-user
        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] user newUser)
        {
            // Generate a unique ID (You can use a more sophisticated way to generate unique IDs)
            int newId = users.Count + 1;
            newUser.Id = newId;
            users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newId }, newUser);
        }

        // PUT: api/User/edit-user/{id}
        [HttpPut("edit-user/{id}")]
        public IActionResult EditUser(int id, [FromBody] user updatedUser)
        {
            return Ok(_userService.updateUser(id, updatedUser));
        }

        // DELETE: api/User/delete-user/{id}
        [HttpDelete("delete-user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userService.deleteUser(id));
        }
    }
}
