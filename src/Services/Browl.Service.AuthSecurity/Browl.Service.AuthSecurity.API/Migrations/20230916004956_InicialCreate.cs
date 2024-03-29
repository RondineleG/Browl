﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Browl.Service.AuthSecurity.API.Migrations;

/// <inheritdoc />
public partial class InicialCreate : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		var unused27 = migrationBuilder.EnsureSchema(
			name: "Identity");

		var unused26 = migrationBuilder.CreateTable(
			name: "Role",
			schema: "Identity",
			columns: table => new
			{
				Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
				Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				var unused25 = table.PrimaryKey("PK_Role", x => x.Id);
			});

		var unused24 = migrationBuilder.CreateTable(
			name: "User",
			schema: "Identity",
			columns: table => new
			{
				Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
				UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
				FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
				LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
				UserNameChangeLimit = table.Column<int>(type: "int", nullable: false),
				ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
				Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
				Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
				PasswordConfirmation = table.Column<string>(type: "nvarchar(max)", nullable: false),
				NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
				EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
				PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
				SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
				ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
				PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
				PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
				TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
				LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
				LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
				AccessFailedCount = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				var unused23 = table.PrimaryKey("PK_User", x => x.Id);
			});

		var unused22 = migrationBuilder.CreateTable(
			name: "RoleClaims",
			schema: "Identity",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
				ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
				ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				var unused21 = table.PrimaryKey("PK_RoleClaims", x => x.Id);
				var unused20 = table.ForeignKey(
					name: "FK_RoleClaims_Role_RoleId",
					column: x => x.RoleId,
					principalSchema: "Identity",
					principalTable: "Role",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		var unused19 = migrationBuilder.CreateTable(
			name: "UserClaims",
			schema: "Identity",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
				ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
				ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				var unused18 = table.PrimaryKey("PK_UserClaims", x => x.Id);
				var unused17 = table.ForeignKey(
					name: "FK_UserClaims_User_UserId",
					column: x => x.UserId,
					principalSchema: "Identity",
					principalTable: "User",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		var unused16 = migrationBuilder.CreateTable(
			name: "UserLogins",
			schema: "Identity",
			columns: table => new
			{
				LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
				ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
				ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
				UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
			},
			constraints: table =>
			{
				var unused15 = table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
				var unused14 = table.ForeignKey(
					name: "FK_UserLogins_User_UserId",
					column: x => x.UserId,
					principalSchema: "Identity",
					principalTable: "User",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		var unused13 = migrationBuilder.CreateTable(
			name: "UserRoles",
			schema: "Identity",
			columns: table => new
			{
				UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
				RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
			},
			constraints: table =>
			{
				var unused12 = table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
				var unused11 = table.ForeignKey(
					name: "FK_UserRoles_Role_RoleId",
					column: x => x.RoleId,
					principalSchema: "Identity",
					principalTable: "Role",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
				var unused10 = table.ForeignKey(
					name: "FK_UserRoles_User_UserId",
					column: x => x.UserId,
					principalSchema: "Identity",
					principalTable: "User",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		var unused9 = migrationBuilder.CreateTable(
			name: "UserTokens",
			schema: "Identity",
			columns: table => new
			{
				UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
				LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
				Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
				Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				var unused8 = table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
				var unused7 = table.ForeignKey(
					name: "FK_UserTokens_User_UserId",
					column: x => x.UserId,
					principalSchema: "Identity",
					principalTable: "User",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		var unused6 = migrationBuilder.CreateIndex(
			name: "RoleNameIndex",
			schema: "Identity",
			table: "Role",
			column: "NormalizedName",
			unique: true,
			filter: "[NormalizedName] IS NOT NULL");

		var unused5 = migrationBuilder.CreateIndex(
			name: "IX_RoleClaims_RoleId",
			schema: "Identity",
			table: "RoleClaims",
			column: "RoleId");

		var unused4 = migrationBuilder.CreateIndex(
			name: "EmailIndex",
			schema: "Identity",
			table: "User",
			column: "NormalizedEmail");

		var unused3 = migrationBuilder.CreateIndex(
			name: "UserNameIndex",
			schema: "Identity",
			table: "User",
			column: "NormalizedUserName",
			unique: true,
			filter: "[NormalizedUserName] IS NOT NULL");

		var unused2 = migrationBuilder.CreateIndex(
			name: "IX_UserClaims_UserId",
			schema: "Identity",
			table: "UserClaims",
			column: "UserId");

		var unused1 = migrationBuilder.CreateIndex(
			name: "IX_UserLogins_UserId",
			schema: "Identity",
			table: "UserLogins",
			column: "UserId");

		var unused = migrationBuilder.CreateIndex(
			name: "IX_UserRoles_RoleId",
			schema: "Identity",
			table: "UserRoles",
			column: "RoleId");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropTable(
			name: "RoleClaims",
			schema: "Identity");
		_ = migrationBuilder.DropTable(
			name: "UserClaims",
			schema: "Identity");
		_ = migrationBuilder.DropTable(
			name: "UserLogins",
			schema: "Identity");
		_ = migrationBuilder.DropTable(
			name: "UserRoles",
			schema: "Identity");
		_ = migrationBuilder.DropTable(
			name: "UserTokens",
			schema: "Identity");
		_ = migrationBuilder.DropTable(
			name: "Role",
			schema: "Identity");
		_ = migrationBuilder.DropTable(
			name: "User",
			schema: "Identity");
	}
}
