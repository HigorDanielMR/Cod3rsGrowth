using FluentMigrator;

namespace Cod3rsGrowth.Infra.CriacaoDasTabelas
{
    [Migration(20240611093100)]
    public class CriandoTabelas : Migration
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

            Create.Table("Vendas")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Cpf").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("DataDeCompra").AsDateTime().NotNullable()
                .WithColumn("ValorTotal").AsDecimal().NotNullable()
                .WithColumn("Pago").AsBoolean();

            Create.Table("VendasCarros")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdVenda").AsInt32().ForeignKey("Vendas", "Id")
                .WithColumn("IdCarro").AsInt32().ForeignKey("Carros", "Id");

            Create.ForeignKey("chave_para_id_venda")
            .FromTable("VendasCarros").ForeignColumn("IdVenda")
            .ToTable("Vendas").PrimaryColumn("Id");

            Create.ForeignKey("chave_para_id_carro")
            .FromTable("VendasCarros").ForeignColumn("IdCarro")
            .ToTable("Carros").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Carros");
            Delete.Table("Vendas");
            Delete.Table("VendasCarros");
        }
    }
}
