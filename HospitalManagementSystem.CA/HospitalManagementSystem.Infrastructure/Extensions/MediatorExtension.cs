using MediatR;
using Microsoft.Extensions.DependencyInjection;
using HospitalManagementSystem.Domains.Common.Interfaces;
using HospitalManagementSystem.Domains.Common;

namespace Hospital_Management_System_Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static void RegisterInfrastructure(this IServiceCollection services) => services.Services();

        private static void Services(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
        }
    }
}
