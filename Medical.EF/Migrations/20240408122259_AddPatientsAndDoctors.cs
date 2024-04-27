using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientsAndDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Governrate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adreess = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ScienceDegree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromDay = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ToDay = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FromHour = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ToHour = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NewCheckPrie = table.Column<double>(type: "float", nullable: false),
                    ReCheckPrie = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Phone);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    Heart = table.Column<bool>(type: "bit", nullable: false),
                    Diabetes = table.Column<bool>(type: "bit", nullable: false),
                    Pressure = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Phone);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
