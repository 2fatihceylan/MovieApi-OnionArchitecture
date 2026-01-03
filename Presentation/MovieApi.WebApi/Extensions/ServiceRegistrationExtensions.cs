using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandler;

namespace MovieApi.WebApi.Extensions
{
    public static class ServiceRegistrationExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //CQRS
            services.AddScoped<GetCategoryQueryHandlers>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommadHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<GetMovieWithCategoryQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();
            services.AddScoped<GetSeriesQueryHandler>();
            services.AddScoped<GetSeriesByIdQueryHandler>();
            services.AddScoped<UpdateSeriesCommandHandler>();
            services.AddScoped<RemoveSeriesCommandHandler>();
            services.AddScoped<CreateSeriesCommandHandler>();




            services.AddScoped<CreateUserRegisterCommandHandler>();

            return services;
        }
    }
}
