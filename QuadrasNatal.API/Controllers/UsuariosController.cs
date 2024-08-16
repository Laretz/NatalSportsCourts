using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuadrasNatal.API.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post(){

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