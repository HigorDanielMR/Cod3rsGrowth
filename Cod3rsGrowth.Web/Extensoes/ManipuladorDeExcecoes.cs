using Newtonsoft.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace Cod3rsGrowth.Web.DetalhesDosProblemas
{
    public static class ManipuladorDeExcecoes
    {
        public static void UsarManipuladorDeExcecaoDeDetalhesDoProblema(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var manipulandoExcecoes = context.Features.Get<IExceptionHandlerFeature>();

                    if (manipulandoExcecoes != null)
                    {
                        var excecao = manipulandoExcecoes.Error; 
                        
                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };

                        if (excecao is ValidationException validationException)
                        {
                            problemDetails.Title = "Erro de validação do FluentValidation";
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = excecao.StackTrace;
                            problemDetails.Extensions["Erros de validação: "] = excecao.Message.Split("\r\n");
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Erro inesperado: {manipulandoExcecoes.Error}");
                            problemDetails.Title = "Erro de requisição de tarefas";
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = excecao.StackTrace;
                            problemDetails.Extensions["Erros"] = excecao.Message.Split("\r\n");
                        }

                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/problem+json";
                        var jsonConvertido = JsonConvert.SerializeObject(problemDetails);
                        await context.Response.WriteAsync(jsonConvertido);
                    }
                });
            });
        }
    }
}
