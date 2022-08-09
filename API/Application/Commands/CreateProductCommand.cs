using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public Product _product { get; set; }

        public CreateProductCommand(Product Product)
        {
            _product = Product;
        }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
        {
            private readonly FakeProductDB _fakeDataStore;
            public CreateProductCommandHandler(FakeProductDB fakeDataStore)
            {
                _fakeDataStore = fakeDataStore;
            }
            public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Code = command._product.Code;
                product.Name = command._product.Name;
                product.Price = command._product.Price;
                await _fakeDataStore.AddProduct(product);
                return product;
            }
        }
    }
}
