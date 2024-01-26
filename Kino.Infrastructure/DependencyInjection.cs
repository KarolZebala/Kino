using Kino.Domain.Actor.Interfaces;
using Kino.Domain.Director.Interfaces;
using Kino.Domain.Movie.Interfaces;
using Kino.Domain.MovieItem.Interfaces;
using Kino.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services) 
        {
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieItemRepository, MovieItemRepository>();
            return services;
        }
    }
}
