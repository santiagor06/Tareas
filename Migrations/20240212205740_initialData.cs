using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class initialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c11"), null, "Trabajo", 10 },
                    { new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c12"), null, "Ocio", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "Fecha", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c13"), new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c11"), null, new DateTime(2024, 2, 12, 15, 57, 39, 849, DateTimeKind.Local).AddTicks(7544), 0, "Aprender .NET" },
                    { new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c15"), new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c12"), null, new DateTime(2024, 2, 12, 15, 57, 39, 849, DateTimeKind.Local).AddTicks(7557), 2, "Jugar Play" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c13"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c15"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c11"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c12"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
