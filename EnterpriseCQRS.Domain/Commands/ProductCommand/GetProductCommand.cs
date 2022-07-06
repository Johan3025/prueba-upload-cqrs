using EnterpriseCQRS.Data.Entities;
using EnterpriseCQRS.Domain.Responses;

namespace EnterpriseCQRS.Domain.Commands.ProductCommand
{
    public class GetProductCommand : BaseCommand<GenericResponse<Product>>
    {
        public int ProductId { get; set; }
    }
}
