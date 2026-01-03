namespace MovieApi.WebApi.Extensions
{
    public static class SwaggerExtenisons
    {


        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            //Swagger eklenmesi
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo { Title = "My Api", Version = "v1" });
            });

            return services;
        }
    }
}
