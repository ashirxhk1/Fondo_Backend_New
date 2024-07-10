﻿using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBookWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataBaseContext _dBContext;

        public AccountController(DataBaseContext dbContext)
        {
            _dBContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<bool> Registration([FromBody] RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userAccount = new UserAccount
                {
                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ConfirmPassword = model.ConfirmPassword,
                    DateOfBirth = model.DateOfBirth,
                    UserName = model.UserName,
                    Gender = model.Gender,
                    
                };

                try
                {
                    _dBContext.UserAccounts.Add(userAccount);
                    await _dBContext.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Email already exists");
                    return false;
                }
            }
            return false;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {
                var user =  _dBContext.UserAccounts.FirstOrDefault(x => x.UserName == login.UserName);

                if (user != null && (login.Password == user.Password) && (login.UserName == user.UserName))
                {
                    var accessToken = "user_" + Guid.NewGuid();
                    return Ok(new { Id = user.Id,accessToken = accessToken});

                }
                return Ok("");
            }
            return Ok("");
        }
    }
}
