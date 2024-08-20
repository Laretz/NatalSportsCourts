using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.API.Models;
using QuadrasNatal.API.Persistence;

namespace QuadrasNatal.API.Controllers

{
    [Route("api/[Controller]")]
    [ApiController]
    public class CourtsController : ControllerBase
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public CourtsController(QuadrasNatalDbContext contextDb)
        {
            _contextDb = contextDb;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var court = _contextDb.Courts
            .Include(c => c.Reservations)
            .Include(c => c.Comments)
            .SingleOrDefault(c => c.Id == id);

            var model = QuadraViewModel.FromEntity(court);
           
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = ""){

            var courts = _contextDb.Courts
            .Include(c => c.Reservations)
            .Where(c => !c.IsDeleted).ToList();

            var model = courts.Select(QuadraViewModel.FromEntity).ToList();

            return Ok(model);
        }
        [HttpPost]
        public async Task <IActionResult> Post(CreateQuadraInputModel model)
        {
            var court = model.ToEntity();

            _contextDb.Courts.Add(court);
            _contextDb.SaveChanges();

            return CreatedAtAction (nameof(GetById), new {id = 1} , model);
        }
       
       
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, UpdateQuadraInputModel model)
        {
            var court = _contextDb.Courts.SingleOrDefault(c => c.Id == id);

            if (court is null)
            {
                return NotFound();
            }

            court.Update(model.Name, model.Description, model.TipoSuperficie);

            _contextDb.Courts.Update(court);
            _contextDb.SaveChanges();

            

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Deletar(int id)
        {
            var court = _contextDb.Courts.SingleOrDefault(c => c.Id == id);

            if (court is null)
            {
                return NotFound();
            }
            court.SetAsDeleted();

            _contextDb.Courts.Update(court);
            _contextDb.SaveChanges();

            return Ok();
        }
        
    }
}