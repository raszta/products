using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<FakeProductDB>();

        }
    }
}
