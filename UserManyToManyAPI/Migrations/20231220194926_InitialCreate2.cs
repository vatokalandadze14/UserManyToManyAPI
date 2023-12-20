using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManyToManyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premission_Role_Roleid",
                table: "Premission");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Users_Userid",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Userid",
                table: "Roles",
                newName: "IX_Roles_Userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "id");

            migrationBuilder.CreateTable(
                name: "RolePremissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleIdid = table.Column<int>(type: "int", nullable: false),
                    PremissionIdid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePremissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePremissions_Premission_PremissionIdid",
                        column: x => x.PremissionIdid,
                        principalTable: "Premission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePremissions_Roles_RoleIdid",
                        column: x => x.RoleIdid,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdid = table.Column<int>(type: "int", nullable: false),
                    RoleIdid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleIdid",
                        column: x => x.RoleIdid,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserIdid",
                        column: x => x.UserIdid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePremissions_PremissionIdid",
                table: "RolePremissions",
                column: "PremissionIdid");

            migrationBuilder.CreateIndex(
                name: "IX_RolePremissions_RoleIdid",
                table: "RolePremissions",
                column: "RoleIdid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleIdid",
                table: "UserRoles",
                column: "RoleIdid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserIdid",
                table: "UserRoles",
                column: "UserIdid");

            migrationBuilder.AddForeignKey(
                name: "FK_Premission_Roles_Roleid",
                table: "Premission",
                column: "Roleid",
                principalTable: "Roles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_Userid",
                table: "Roles",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premission_Roles_Roleid",
                table: "Premission");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_Userid",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "RolePremissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Userid",
                table: "Role",
                newName: "IX_Role_Userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Premission_Role_Roleid",
                table: "Premission",
                column: "Roleid",
                principalTable: "Role",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Users_Userid",
                table: "Role",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
