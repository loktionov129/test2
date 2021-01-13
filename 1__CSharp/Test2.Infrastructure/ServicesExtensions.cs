using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Test2.DataAccess;
using Test2.DataAccess.Repositories;
using Test2.Domain.Figures.Commands;
using Test2.Domain.Figures.Handlers;
using Test2.Domain.Figures.Queries;
using Test2.Domain.Figures.Repositories;

namespace Test2.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterDomain(this IServiceCollection services)
        {
            services.AddScoped(typeof(AppDbContext));
            services.AddScoped(typeof(IFigureRepository), typeof(FigureRepository));
            services.AddScoped(typeof(IRequestHandler<CreateFigureCommand, int>), typeof(CreateFigureCommandHandler));
            services.AddScoped(typeof(IRequestHandler<GetFigureAreaByIdQuery, double>), typeof(GetFigureAreaByIdQueryHandler));

            return services;
        }
    }
}