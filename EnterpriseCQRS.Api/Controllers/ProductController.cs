using EnterpriseCQRS.Data.Entities;
using EnterpriseCQRS.Domain.Commands.ProductCommand;
using EnterpriseCQRS.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnterpriseCQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IMediator _mediator { get; }

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("CalculateQuote")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GenericResponse<Product>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse<Product>))]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductCommand query)
        {
            var response = await _mediator.Send(query);

            if (response is null)
            {
                return NotFound();
            }

            return response.Error is null ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
