using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuadrasNatal.API.Models;

namespace QuadrasNatal.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        [HttpGet]
        public  async Task<IActionResult> GellAll()
        {
            return Ok();
        }
         //POST api/reservas
        [HttpPost]
        public async Task<IActionResult> Post(CreateReservaInputModel model)
        {
            return Ok();
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
        public async Task<IActionResult> Deletada(int id)
        {
            return NoContent();
        }
    }
}