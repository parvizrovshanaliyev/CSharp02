using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class CommentUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f20b855-bfb0-4e66-92ea-ed2dbb780001", "AQAAAAEAACcQAAAAECD1pxbR/0l0+N/bVZ0IvBZv+3UFOGSyNCHULOhG0h2MBk3gzbgHHuarI4/Vx6U/DA==" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d61e3fc-a2dc-4b16-ae08-a11aa7ec24b5", "AQAAAAEAACcQAAAAEIDbO+immrv1iL4t9GfnlkjtgVmu5E2jgPN1zABgfI+Ir1bmfYuM7goTAktoElpItA==" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b0120e6-00ad-4ca7-a978-79de0ee79f54", "AQAAAAEAACcQAAAAEKkucDrwNxL89SvxMRXpcUSMz7/zhNiX8FQVnL5p3Mfou4P5K3IHMB5kxpR+TW/Mew==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bcce8cf9-2b60-4c75-b050-24ad490bf5de", "AQAAAAEAACcQAAAAEDFclzZKfSNnDTReNYKJPS+c05Mcbe4vPKjoE5oUzuEd5bM7m1Lel6iJqE3IKuVA9g==" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20d75ec2-f7e7-4727-87e7-16e4714f61af", "AQAAAAEAACcQAAAAEGU7CIBz+czMirQI9q4fYjbHpvFT/0++nzhc5zO4tuza6sJVptrrVoRWv7me/MLjlg==" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1db50c7-2bc7-4344-a7a1-a4a71f00aa66", "AQAAAAEAACcQAAAAEHa3x9gFBUdFOwes6VSEr9juKoxl7mm6boNsBYEeQ+gzFBCz/+1+Os301XZEcKthwA==" });
        }
    }
}
