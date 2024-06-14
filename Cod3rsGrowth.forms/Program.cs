using System.Configuration;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.Extensions.Hosting;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.CriacaoDasTabelas;
using MongoDB.Driver.Core.Configuration;
using Cod3rsGrowth.Forms;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var serviceProvider = CreateServices();

            using(serviceProvider)
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDataBase(scope.ServiceProvider);
                Application.Run(serviceProvider.GetRequiredService<FormListagemCarro>());
                Application.Run(serviceProvider.GetRequiredService<FormListagemVenda>());
            }
        }

        
        private static ServiceProvider CreateServices()
        {
            var conectionstring = ConfigurationManager.ConnectionStrings["ConexaoComBanco"].ToString();

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(conectionstring)
                    .ScanIn(typeof(CriandoTabelas).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())

                .AddTransient<ServicoCarro>()
                .AddTransient<ServicoVenda>()
                .AddTransient<ValidacoesCarro>()
                .AddTransient<ValidacoesVenda>()
                .AddTransient<IRepositorioCarro, RepositorioCarro>()
                .AddTransient<IRepositorioVenda, RepositorioVenda>()
                .AddTransient<FormListagemCarro>()
                .AddTransient<FormListagemVenda>()
                .AddTransient<ValidacoesCarro>()
                .AddTransient<ValidacoesVenda>()

                
                .BuildServiceProvider(false);
        }

            private static void UpdateDataBase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}