using Backend.Services;

namespace Backend.Extensions
{
    public static class AppExtension
    {
        public static WebApplication AddSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }

        public static WebApplication AddGrpc(this WebApplication app)
        {
            app.MapGrpcService<LoansService>();
            app.MapGrpcReflectionService();
            return app;
        }
    }
}
