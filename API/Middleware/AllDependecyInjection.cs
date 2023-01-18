using Core.Interfaces.GenericInterface;
using Core.Interfaces.PageInterface;
using Service;
using Service.Repositories.GenericRepositories;

namespace API.Middleware
{
    public static class AllDependecyInjection
    {
        public static IServiceCollection AddInjections(
                this IServiceCollection services)
        {
            #region Generic
            services.AddTransient(typeof(IGenericCrudRepository<>), typeof(GenericCrudRepository<>));
            #endregion
            #region Service
            services.AddScoped<ISingerService, SingerService>();
            services.AddScoped<ISongService, SongService>();
            #endregion
            return services;
        }
    }
}
