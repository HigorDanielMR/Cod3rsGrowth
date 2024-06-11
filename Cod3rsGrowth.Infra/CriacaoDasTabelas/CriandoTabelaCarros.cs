using FluentMigrator;

namespace Cod3rsGrowth.Infra.CriacaoDasTabelas
{
    [Migration(20240611093100)]
    public class CriandoTabelaCarros : Migration
    {
        public override void Up()
        {
            Create.Table("Carros")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Modelo").AsString().NotNullable()
                .WithColumn("Marca").AsInt32()
                .WithColumn("Cor").AsInt32()
                .WithColumn("ValorDoVeiculo").AsDecimal()
                .WithColumn("Flex").AsBoolean();
        }
        public override void Down()
        {
            Delete.Table("Carros");
        }
    }
}
