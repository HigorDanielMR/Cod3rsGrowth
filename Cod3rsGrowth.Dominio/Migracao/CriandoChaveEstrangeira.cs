using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracao
{
    [Migration(24062024115100)]
    internal class CriandoChaveEstrangeira : Migration
    {
        public override void Up()
        {
            Create.ForeignKey("chave_para_id_carro")
            .FromTable("Venda").ForeignColumn("IdDoCarroVendido")
            .ToTable("Carro").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.ForeignKey("chave_para_id_carro");
        }
    }
}
