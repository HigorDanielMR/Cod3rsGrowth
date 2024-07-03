using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.DetalhesDosProblemas
{
    public static class ConfigurarDetalhes
    {
        public static IServiceCollection ConfigurarOEstadoDoModeloDeDetalhesDoProblema(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Modelo inválido."
                    };
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });
        }
    }
}
