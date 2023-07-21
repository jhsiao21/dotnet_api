using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //    private static List<User> _users = new List<User>()
        //{
        //    new User() { UserId = 0, UserName = "Alice", Email = "alice@gmail.com"},
        //    new User() { UserId = 1, UserName = "Bob", Email = "Bob@gmail.com"},
        //    new User() { UserId = 2, UserName = "Cathy", Email = "Cathy@gmail.com"}
        //};

        private readonly IUserCRUD _user;
        public UsersController(IUserCRUD user)
        {
            _user = user;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _user.GetAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _user.GetUserById(id);
            if (user == null)
            {
                throw new Exception("找不到 user");
            }
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post(User user)
        {
            _user.CreateUser(user);
        }

        [HttpPut("{id}")]
        public void Put(int id, User newUserData)
        {
            _user.UpdateUser(id, newUserData);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _user.DeleteUser(id);
        }
    }
}
