using Cod3rsGrowth.Forms;
using System.Configuration;
using FluentMigrator.Runner;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Dominio.CriacaoDasTabelas;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.forms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var serviceProvider = CreateServices();

            using (serviceProvider)
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDataBase(scope.ServiceProvider);
                Application.Run(serviceProvider.GetRequiredService<FormListagem>());
            }
        }

        public static ServiceProvider CreateServices()
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
                .AddTransient<FormListagem>()
                .AddTransient<CriandoVenda>()
                .AddTransient<CriandoCarro>()

                .BuildServiceProvider(false);
        }

        private static void UpdateDataBase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}