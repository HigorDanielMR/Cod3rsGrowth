using System.Configuration;
using FluentMigrator.Runner;
using Microsoft.Extensions.Hosting;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Infra.ConexaoComBanco;
using Cod3rsGrowth.Dominio.CriacaoDasTabelas;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.forms
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var serviceProvider = CriarServicoDeMigracao())
            using (var scopo = serviceProvider.CreateScope())
            {
                AtualizarBancoDeDados(scopo.ServiceProvider);
            }

            var host = CriarHostBuider().Build();
            ServiceProvider = host.Services;
            Application.Run(ServiceProvider.GetRequiredService<FormListagem>());
        }

        public static ServiceProvider CriarServicoDeMigracao()
        {
            var conectionstring = ConfigurationManager.ConnectionStrings["ConexaoComBanco"].ToString();

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(conectionstring)
                    .ScanIn(typeof(CriandoTabelaCarro).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        static IHostBuilder CriarHostBuider()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((contexto, servicos) =>
                {
                    var stringDeConexao = ConfigurationManager.ConnectionStrings["ConexaoComBanco"].ToString();

                    servicos.AddTransient<ServicoCarro>();
                    servicos.AddTransient<ServicoVenda>();
                    servicos.AddTransient<FormListagem>();
                    servicos.AddTransient<ValidacoesCarro>();
                    servicos.AddTransient<ValidacoesVenda>();
                    servicos.AddTransient<IRepositorioCarro, RepositorioCarro>();
                    servicos.AddTransient<IRepositorioVenda, RepositorioVenda>();
                    servicos.AddScoped(provider => new MeuContextoDeDados(stringDeConexao));
                });
        }

        private static void AtualizarBancoDeDados(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}