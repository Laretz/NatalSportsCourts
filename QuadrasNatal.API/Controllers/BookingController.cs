using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuadrasNatal.API.Entities;
using QuadrasNatal.API.Models;
using QuadrasNatal.API.Persistence;

namespace QuadrasNatal.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
         private readonly QuadrasNatalDbContext _contextDb;
         public BookingController(QuadrasNatalDbContext contextDb )
         {
            _contextDb = contextDb;
         }
        [HttpGet]
        public  async Task<IActionResult> GellAll(string search = "" )
        {
            var bookings = _contextDb.Reservas.ToList();

            var model = bookings.Select(ReservaViewModel.FromEntity).ToList();
            return Ok();
        }
         //POST api/reservas
        [HttpPost]
        public async Task<IActionResult> Post(CreateReservaInputModel model)
        {
            var reserva = model.ToEntity();
            _contextDb.Reservas.Add(reserva);
            _contextDb.SaveChanges();
            
            return Ok(model);
        }

        [HttpPost("{id}/comentarios")]
        public async Task<IActionResult> PostComment(int id, CreateReservaCommentarioInputModel model)
        {
            return NoContent();
        }
        [HttpPut("{id}/iniciada")]
        public async Task<IActionResult> Start(int id, UpdateQuadraInputModel model)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateQuadraInputModel model)
        {   
            return Ok();
        }

        [HttpPut("{id}/finalizada")]
        public async Task<IActionResult> Finalizada(int id, UpdateQuadraInputModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}