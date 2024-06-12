using FluentMigrator.Runner;
using Cod3rsGrowth.Infra.CriacaoDasTabelas;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

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
            Application.Run(new Form1());

            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDataBase(scope.ServiceProvider);
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
                .BuildServiceProvider(false);
        }

            private static void UpdateDataBase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}