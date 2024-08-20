using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.API.Entities;
using QuadrasNatal.API.Models;
using QuadrasNatal.API.Persistence;

namespace QuadrasNatal.API.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public UsersController(QuadrasNatalDbContext contextDb)
        {
            _contextDb = contextDb;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
             var user = _contextDb.Users
             .Include(u => u.Reservas)
                .SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            var model = UserViewModel.FromEntity(user);

            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserInputModel model){
            
            var user = new User (model.FullName, model.Email, model.BithDate);

            _contextDb.Users.Add(user);
            _contextDb.SaveChanges();


            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (UpdateUserInputModel model){
            return Ok();
        }
        
        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"FIle: {file.FileName}, Size: {file.Length}";

            // Processar a imagem

            return Ok(description);
        }


    }
}