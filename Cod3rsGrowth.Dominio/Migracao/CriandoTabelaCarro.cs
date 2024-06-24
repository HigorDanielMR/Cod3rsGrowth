using FluentMigrator;

namespace Cod3rsGrowth.Dominio.CriacaoDasTabelas
{
    [Migration(20240614123100)]
    public class CriandoTabelaCarro : Migration
    {
        public override void Up()
        {
            Create.Table("Carro")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Modelo").AsString().NotNullable()
                .WithColumn("Marca").AsInt32()
                .WithColumn("Cor").AsInt32()
                .WithColumn("ValorDoVeiculo").AsDecimal(16,2)
                .WithColumn("Flex").AsBoolean();

        }
        public override void Down()
        {
            Delete.Table("Carro");
        }
    }
}
