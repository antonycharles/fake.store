using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Infrastructure.Migrations
{
    public partial class changeNToN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsProfiles_Clients_ClientEntityId",
                table: "ClientsProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientsProfiles_Profiles_ProfileEntityId",
                table: "ClientsProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilesRoles_Profiles_ProfileEntityId",
                table: "ProfilesRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilesRoles_Roles_RoleEntityId",
                table: "ProfilesRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_Profiles_ProfileEntityId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_Users_UserEntityId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_ProfileEntityId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_UserEntityId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ProfilesRoles_ProfileEntityId",
                table: "ProfilesRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProfilesRoles_RoleEntityId",
                table: "ProfilesRoles");

            migrationBuilder.DropIndex(
                name: "IX_ClientsProfiles_ClientEntityId",
                table: "ClientsProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ClientsProfiles_ProfileEntityId",
                table: "ClientsProfiles");

            migrationBuilder.DropColumn(
                name: "ProfileEntityId",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "ProfileEntityId",
                table: "ProfilesRoles");

            migrationBuilder.DropColumn(
                name: "RoleEntityId",
                table: "ProfilesRoles");

            migrationBuilder.DropColumn(
                name: "ClientEntityId",
                table: "ClientsProfiles");

            migrationBuilder.DropColumn(
                name: "ProfileEntityId",
                table: "ClientsProfiles");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_UserId",
                table: "UsersProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilesRoles_RoleId",
                table: "ProfilesRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsProfiles_ClientId",
                table: "ClientsProfiles",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsProfiles_Clients_ClientId",
                table: "ClientsProfiles",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsProfiles_Profiles_ProfileId",
                table: "ClientsProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilesRoles_Profiles_ProfileId",
                table: "ProfilesRoles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilesRoles_Roles_RoleId",
                table: "ProfilesRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_Profiles_ProfileId",
                table: "UsersProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_Users_UserId",
                table: "UsersProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsProfiles_Clients_ClientId",
                table: "ClientsProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientsProfiles_Profiles_ProfileId",
                table: "ClientsProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilesRoles_Profiles_ProfileId",
                table: "ProfilesRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilesRoles_Roles_RoleId",
                table: "ProfilesRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_Profiles_ProfileId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_Users_UserId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_UserId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ProfilesRoles_RoleId",
                table: "ProfilesRoles");

            migrationBuilder.DropIndex(
                name: "IX_ClientsProfiles_ClientId",
                table: "ClientsProfiles");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileEntityId",
                table: "UsersProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "UsersProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileEntityId",
                table: "ProfilesRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleEntityId",
                table: "ProfilesRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientEntityId",
                table: "ClientsProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileEntityId",
                table: "ClientsProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_ProfileEntityId",
                table: "UsersProfiles",
                column: "ProfileEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_UserEntityId",
                table: "UsersProfiles",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilesRoles_ProfileEntityId",
                table: "ProfilesRoles",
                column: "ProfileEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilesRoles_RoleEntityId",
                table: "ProfilesRoles",
                column: "RoleEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsProfiles_ClientEntityId",
                table: "ClientsProfiles",
                column: "ClientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsProfiles_ProfileEntityId",
                table: "ClientsProfiles",
                column: "ProfileEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsProfiles_Clients_ClientEntityId",
                table: "ClientsProfiles",
                column: "ClientEntityId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsProfiles_Profiles_ProfileEntityId",
                table: "ClientsProfiles",
                column: "ProfileEntityId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilesRoles_Profiles_ProfileEntityId",
                table: "ProfilesRoles",
                column: "ProfileEntityId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilesRoles_Roles_RoleEntityId",
                table: "ProfilesRoles",
                column: "RoleEntityId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_Profiles_ProfileEntityId",
                table: "UsersProfiles",
                column: "ProfileEntityId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_Users_UserEntityId",
                table: "UsersProfiles",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
