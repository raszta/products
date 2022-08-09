using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly FakeProductDB _fakeDataStore;
            public GetAllProductsQueryHandler(FakeProductDB fakeDataStore)
            {
                _fakeDataStore = fakeDataStore;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _fakeDataStore.GetAllProducts();
                if (productList == null)
                {
                    return null;
                }
                return productList;
            }
        }
    }
}
