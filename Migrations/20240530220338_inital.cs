using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PURE.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_EVENTO_MOCK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_Eventp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Local_Evento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Evento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Hora_Inicial_do_Evento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pontos_Evento = table.Column<float>(type: "BINARY_FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EVENTO_MOCK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Hash_Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Usuario_Ativo = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_EVENTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nome_Eventp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Local_Evento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Evento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Hora_Inicial_do_Evento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pontos_Evento = table.Column<float>(type: "BINARY_FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EVENTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_EVENTO_T_USUARIO_UserId",
                        column: x => x.UserId,
                        principalTable: "T_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "T_EVENTO_MOCK",
                columns: new[] { "Id", "Descricao", "Data_Evento", "Local_Evento", "Nome_Eventp", "Pontos_Evento", "Hora_Inicial_do_Evento" },
                values: new object[,]
                {
                    { 1, "Nesse encontro vamos fazer o máximo para limpar a nossa praia do cassino, contamos com voce!", "05/06/2024", "Praia do Cassino, RS", "Limpeza Praia do Cassino", 160f, "08:00" },
                    { 2, "Contamos com a ajuda de todos para que conseguimos limpar a praia e voltar sua beleza", "31/05/2024", "Praia Bertioga, SP", "Limpando a praia já!", 90f, "12:00" },
                    { 3, "Queremos deixar nossa praia o mais limpa possivel, venha ajudar a salvar o oceano conosco!!", "12/02/2024", "Praia de Trindade, RJ", "Deixando a praia limpa!", 125f, "09:00" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_EVENTO_UserId",
                table: "T_EVENTO",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_EVENTO");

            migrationBuilder.DropTable(
                name: "T_EVENTO_MOCK");

            migrationBuilder.DropTable(
                name: "T_USUARIO");
        }
    }
}
