using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_MessageReceiverSenderId_column_and_message_writer_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageReceiverId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageSenderId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageReceiverId",
                table: "Messages",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageSenderId",
                table: "Messages",
                column: "MessageSenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Writers_MessageReceiverId",
                table: "Messages",
                column: "MessageReceiverId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Writers_MessageSenderId",
                table: "Messages",
                column: "MessageSenderId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Writers_MessageReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Writers_MessageSenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageSenderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageReceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageSenderId",
                table: "Messages");
        }
    }
}
