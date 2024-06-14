using FluentMigrator;

namespace Cod3rsGrowth.Dominio.CriacaoDasTabelas
{
    [Migration(20240614123100)]
    public class CriandoTabelas : Migration
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

            Create.Table("Venda")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Cpf").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("DataDeCompra").AsDateTime().NotNullable()
                .WithColumn("ValorTotal").AsDecimal(16,2).NotNullable()
                .WithColumn("Pago").AsBoolean();

            Create.Table("VendasCarros")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdVenda").AsInt32().ForeignKey("Venda", "Id")
                .WithColumn("IdCarro").AsInt32().ForeignKey("Carro", "Id");

            Create.ForeignKey("chave_para_id_venda")
            .FromTable("VendasCarros").ForeignColumn("IdVenda")
            .ToTable("Venda").PrimaryColumn("Id");

            Create.ForeignKey("chave_para_id_carro")
            .FromTable("VendasCarros").ForeignColumn("IdCarro")
            .ToTable("Carro").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Carro");
            Delete.Table("Venda");
            Delete.Table("VendasCarros");
        }
    }
}
