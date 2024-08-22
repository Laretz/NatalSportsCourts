using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Infrastructure.Persistence;


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

            var model = CourtViewModel.FromEntity(court);
           
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = ""){

            var courts = _contextDb.Courts
            .Include(c => c.Reservations)
            .Where(c => !c.IsDeleted).ToList();

            var model = courts.Select(CourtViewModel.FromEntity).ToList();

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

            court.Update(model.Name, model.Description, model.SurfaceType);

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