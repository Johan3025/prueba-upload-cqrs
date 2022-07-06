using EnterpriseCQRS.Data;
using EnterpriseCQRS.Data.Entities;
using EnterpriseCQRS.Domain.Commands.ProductCommand;
using EnterpriseCQRS.Domain.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseCQRS.Services.CommandHandlers.ProductCommandHandler
{
    public class ProductCommandHandler
    {
        public class CalculateQuoteCommandHandler : IRequestHandler<GetProductCommand, GenericResponse<Product>>
        {
            private readonly CommittedCapacityContext _context;

            public CalculateQuoteCommandHandler(CommittedCapacityContext context)
            {
                _context = context;
            }

            public async Task<GenericResponse<Product>> Handle(GetProductCommand request, CancellationToken cancellationToken)
            {
                var response = new GenericResponse<Product>();

                var respo = await  _context.Products.FirstOrDefaultAsync(cancellationToken); 
                response.Result = respo;

                return response;

            }
        }
    }
}
