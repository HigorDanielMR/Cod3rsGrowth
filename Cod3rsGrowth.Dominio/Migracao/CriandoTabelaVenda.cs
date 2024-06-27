using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracao
{
    [Migration(24062024114900)]
    public class CriandoTabelaVenda : Migration
    {
        public override void Up()
        {
            Create.Table("Venda")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Cpf").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("IdDoCarroVendido").AsInt32().NotNullable().ForeignKey("Carro", "Id")
                .WithColumn("DataDeCompra").AsDateTime().NotNullable()
                .WithColumn("ValorTotal").AsDecimal(16, 2).NotNullable()
                .WithColumn("Pago").AsBoolean();
        }
        public override void Down()
        {
            Delete.Table("Venda");
        }
    }
}
