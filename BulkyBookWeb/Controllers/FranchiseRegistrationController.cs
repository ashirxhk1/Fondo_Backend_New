using BulkyBookWeb.Data;
using BulkyBookWeb.DTOs;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BulkyBookWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchiseRegistrationController : ControllerBase
    {
        private readonly DataBaseContext _dBContext;

        public FranchiseRegistrationController(DataBaseContext dbContext)
        {
            _dBContext = dbContext;
        }

        [HttpPost("SaveFrachsie")]
        public async Task<IActionResult> SaveFrachsie([FromBody] Franchise model)
        {
            if (ModelState.IsValid)
            {
                var userAccount = new Franchise
                {
                    Name = model.Name,
                    UserId = model.UserId,
                };

                try
                {
                    _dBContext.Franchises.Add(userAccount);
                    await _dBContext.SaveChangesAsync();
                    return Ok(true);
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Email already exists");
                    return BadRequest(ModelState);
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new { Errors = errors });
        }

        [HttpPost("saveResurant")]
        public async Task<IActionResult> SaveResurant([FromForm] RestuarntDto formData)
        {
            if (ModelState.IsValid)
            {
                var RESTURANT = new Restaurant
                {
                    Neighborhood = formData.Neighborhood,
                    City = formData.City,
                    Specialty = formData.Specialty,
                    StartDate = new DateTime(),
                    ContactName = formData.ContactName,
                    Country = formData.Country,
                    Email = formData.Email,
                    State = formData.State,
                    OutsideNumber = formData.OutsideNumber,
                    Password = formData.Password,
                    PhoneNumber = formData.PhoneNumber,
                    Surname = formData.Surname,
                    ReferenceSite = formData.ReferenceSite,
                    ZipCode = formData.ZipCode,
                    RestaurantName = formData.RestaurantName,
                    InnerNumber = formData.InnerNumber,
                    UserId = formData.UserId,
                };

                try
                {
                    _dBContext.Restuarants.Add(RESTURANT);
                    await _dBContext.SaveChangesAsync();
                    return Ok(true);
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Email already exists");
                    return BadRequest(ModelState);
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new { Errors = errors });
        }

        [HttpGet("IsRestuantCreated")]
       public async Task<IActionResult> IsRestuantCreated(int UserId) {

            var res = await _dBContext.Restuarants.Where(x => x.UserId == UserId).Select(x=>new RestuarntDto
            {
                Id  = x.Id,
                OutsideNumber = x.OutsideNumber,   
                City = x.City,  
                Specialty = x.Specialty,
                ContactName = x.ContactName,
                Country = x.Country,    
                Email = x.Email,
                InnerNumber = x.InnerNumber,
                StartDate = x.StartDate,
                Neighborhood = x.Neighborhood,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                ReferenceSite = x.ReferenceSite,    
                RestaurantName = x.RestaurantName,
                State = x.State,
                Surname = x.Surname,
                UserId = UserId,    
                ZipCode = x.ZipCode,
                
                
               

            }).FirstOrDefaultAsync();
                
            return Ok(res); 


        }

        
    }
}
