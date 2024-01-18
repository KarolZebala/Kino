using Kino.Application.Services.Actor;
using Kino.Application.Services.Director;
using Kino.Application.Services.Movie;
using Kino.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddInfrastructureLayer();
            return services;
        }
    }
}
