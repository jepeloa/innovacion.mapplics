using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoirSubscriptionManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_MemberId_Month_Year",
                table: "Subscriptions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Subscription_Month",
                table: "Subscriptions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Subscription_Year",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Subscriptions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Subscriptions",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Subscriptions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Subscriptions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_MemberId_StartDate_EndDate",
                table: "Subscriptions",
                columns: new[] { "MemberId", "StartDate", "EndDate" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Subscription_Dates",
                table: "Subscriptions",
                sql: "EndDate > StartDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_MemberId_StartDate_EndDate",
                table: "Subscriptions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Subscription_Dates",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Subscriptions",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Subscriptions",
                newName: "DueDate");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Subscriptions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Payments",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "Efectivo");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_MemberId_Month_Year",
                table: "Subscriptions",
                columns: new[] { "MemberId", "Month", "Year" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Subscription_Month",
                table: "Subscriptions",
                sql: "Month >= 1 AND Month <= 12");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Subscription_Year",
                table: "Subscriptions",
                sql: "Year >= 2020");
        }
    }
}
