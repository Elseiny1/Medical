using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Numbre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Patient_Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Complaint = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Time = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Am_Pm = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Book_Type = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Numbre);
                    table.ForeignKey(
                        name: "FK_Books_Doctors_Doctor_Phone",
                        column: x => x.Doctor_Phone,
                        principalTable: "Doctors",
                        principalColumn: "Phone",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Patients_Patient_Phone",
                        column: x => x.Patient_Phone,
                        principalTable: "Patients",
                        principalColumn: "Phone",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Doctor_Phone",
                table: "Books",
                column: "Doctor_Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Patient_Phone",
                table: "Books",
                column: "Patient_Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
