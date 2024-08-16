using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuadrasNatal.API.Models;

namespace QuadrasNatal.API.Controllers

{
    [Route("api/[Controller]")]
    [ApiController]
    public class QuadrasController : ControllerBase
    {
        [HttpGet]
        public  IActionResult GetAll(){
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            return Ok();
        }

        [HttpGet("api/nome")]
        public async Task<IActionResult> GetByName(string search = ""){
            return Ok();
        }
        [HttpPost]
        public async Task <IActionResult> Post(CreateQuadraInputModel model)
        {
            return CreatedAtAction (nameof(GetById), new {id = 1} , model);
        }
       
       
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, UpdateQuadraInputModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Deletar(int id)
        {
            return Ok();
        }
        
    }
}