using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly FakeProductDB _fakeDataStore;
            public GetProductByIdQueryHandler(FakeProductDB fakeDataStore)
            {
                _fakeDataStore = fakeDataStore;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _fakeDataStore.GetProductById(query.Id);
                if (product == null) return null;
                return product;
            }
        }
    }
}
