using Newtonsoft.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace Cod3rsGrowth.Web.DetalhesDosProblemas
{
    public static class ExtensaoDosDetalhesDosProblemas
    {
        public static IServiceCollection ConfigureProblemDetailsModelState(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Propriedades invalidas."
                    };
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });
        }

        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;
                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };
                        if (exception is BadHttpRequestException badHttpRequestException)
                        {
                            problemDetails.Title = "Solicitação é inválida.";
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = badHttpRequestException.Message;
                        }
                        else if(exception is ValidationException validationException)
                        {
                            problemDetails.Title = "Erro de validação do FluentValidation";
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = validationException.Message.ToString();
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Erro inesperado: {exceptionHandlerFeature.Error}");
                            problemDetails.Title = "Caiu aqui";
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = exception.Message.ToString();
                        }
                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/problem+json";
                        var json = JsonConvert.SerializeObject(problemDetails);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
