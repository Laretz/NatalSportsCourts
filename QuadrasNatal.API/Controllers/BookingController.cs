using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Application.Services;
using QuadrasNatal.Core.Entities;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly QuadrasNatalDbContext _contextDb;
        private readonly IBookingService _service;
         public BookingController(QuadrasNatalDbContext contextDb, IBookingService service )
         {
            _contextDb = contextDb;
            _service = service;
         }

        //GET api/booking?search=crm
        [HttpGet]
        public  async Task<IActionResult> Get(string search = "")
        {
            var result = _service.GetAll("");
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var result = _service.GetById(id);
            
            if(!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
         //POST api/reservas
        [HttpPost]
        public async Task<IActionResult> Post(CreateBookingInputModel model)
        {
            var result = _service.Insert(model);
            
            return CreatedAtAction(nameof(GetById), new {id = result.Data}, model);
        }

        [HttpPost("{id}/comentarios")]
        public async Task<IActionResult> PostComment(int id, CreateBookingCommentInputModel model)
        {
            var result = _service.InsertComment(id, model);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            
            return NoContent();
        }
        [HttpPut("{id}/iniciada")]
        public async Task<IActionResult> Start(int id, UpdateBookingInputeModel model)
        { 
           var result = _service.Start(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
           
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBookingInputeModel model)
        {   
            var result = _service.Update(model);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
           
            return NoContent();
        }

        [HttpPut("{id}/finalizada")]
        public async Task<IActionResult> Finalizada(int id, UpdateQuadraInputModel model)
        {
            var result = _service.Finish(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
           
            return NoContent();
        }
    }
}