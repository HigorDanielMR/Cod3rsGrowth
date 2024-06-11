using FluentMigrator;

namespace Cod3rsGrowth.Infra.CriacaoDasTabelas
{
    [Migration(20240611093000)]
    public class CriandoTabelaVendas : Migration
    {
        public override void Up()
        {
            Create.Table("Vendas")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Cpf").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("DataDeCompra").AsDateTime().NotNullable()
                .WithColumn("ItensVendidos").AsInt32()
                .WithColumn("ValorTotal").AsDecimal().NotNullable()
                .WithColumn("Pago").AsBoolean();
        }
        public override void Down()
        {
            Delete.Table("Vendas");
        }
    }
}

