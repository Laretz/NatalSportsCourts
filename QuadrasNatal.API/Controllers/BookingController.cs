using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Commands.DeleteBooking;
using QuadrasNatal.Application.Commands.FinishBooking;
using QuadrasNatal.Application.Commands.InsertBooking;
using QuadrasNatal.Application.Commands.InsertComment;
using QuadrasNatal.Application.Commands.StartBooking;
using QuadrasNatal.Application.Commands.UpdateBooking;
using QuadrasNatal.Application.Queries.GetAllBookings;
using QuadrasNatal.Application.Queries.GetBookingById;


namespace QuadrasNatal.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
         {
            _mediator = mediator;
         }

        //GET api/booking?search=crm
        [HttpGet]
        public  async Task<IActionResult> Get(string search = "")
        {
            var query = new GetAllBookingsQuery();

            var result = await _mediator.Send(query);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var result = await  _mediator.Send(new GetBookingByIdQuery(id));
            
            if(!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
         //POST api/reservas
        [HttpPost]
        public async Task<IActionResult> Post(InsertBookingCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            
            return CreatedAtAction(nameof(GetById), new {id = result.Data}, command);
        }

        [HttpPost("{id}/comentarios")]
        public async Task<IActionResult> PostComment(int id, InsertCommentCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            
            return NoContent();
        }
        [HttpPut("{id}/iniciada")]
        public async Task<IActionResult> Start(int id)
        { 
           var result = await _mediator.Send(new StartBookingCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
           
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBookingCommand command)
        {   
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
           
            return NoContent();
        }

        [HttpPut("{id}/finalizada")]
        public async Task<IActionResult> Finalizada(int id)
        {
            var result = await _mediator.Send(new FinishBookingCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBookingCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
           
            return NoContent();
        }
    }
}