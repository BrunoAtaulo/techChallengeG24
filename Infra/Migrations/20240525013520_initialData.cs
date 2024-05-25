using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using System;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class initialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scriptInserts.sql");

            if (File.Exists(sqlFilePath))
            {
                var sqlScript = File.ReadAllText(sqlFilePath);
                migrationBuilder.Sql(sqlScript);
                Console.WriteLine("Script Inicial Realizado com sucesso");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
