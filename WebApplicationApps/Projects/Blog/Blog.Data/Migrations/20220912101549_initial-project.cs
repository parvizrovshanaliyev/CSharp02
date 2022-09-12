using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blog.Data.Migrations
{
    public partial class initialproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    avatar = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    about_me = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    first_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    last_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    youtube_link = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    twitter_link = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    instagram_link = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    facebook_link = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    linked_in_link = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    git_hub_link = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    website_link = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    user_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    created_by_name = table.Column<string>(type: "text", nullable: false),
                    modified_by_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    provider_key = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Identity",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Identity",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    login_provider = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    thumbnail = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    views_count = table.Column<int>(type: "integer", nullable: false),
                    comment_count = table.Column<int>(type: "integer", nullable: false),
                    seo_author = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    seo_description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    seo_tags = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    created_by_name = table.Column<string>(type: "text", nullable: false),
                    modified_by_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_posts", x => x.id);
                    table.ForeignKey(
                        name: "fk_posts_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_posts_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    post_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    created_by_name = table.Column<string>(type: "text", nullable: false),
                    modified_by_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_comments_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comments_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { 1, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Category_Create", "CATEGORY_CREATE" },
                    { 22, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "SuperAdmin", "SUPERADMIN" },
                    { 21, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "AdminArea_Home_Read", "ADMINAREA_HOME_READ" },
                    { 20, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Comment_Delete", "COMMENT_DELETE" },
                    { 19, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Comment_Update", "COMMENT_UPDATE" },
                    { 18, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Comment_Read", "COMMENT_READ" },
                    { 17, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Comment_Create", "COMMENT_CREATE" },
                    { 16, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Role_Delete", "ROLE_DELETE" },
                    { 15, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Role_Update", "ROLE_UPDATE" },
                    { 14, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Role_Read", "ROLE_READ" },
                    { 12, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "User_Delete", "USER_DELETE" },
                    { 13, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Role_Create", "ROLE_CREATE" },
                    { 10, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "User_Read", "USER_READ" },
                    { 9, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "User_Create", "USER_CREATE" },
                    { 8, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Post_Delete", "POST_DELETE" },
                    { 7, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Post_Update", "POST_UPDATE" },
                    { 6, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Post_Read", "POST_READ" },
                    { 5, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Post_Create", "POST_CREATE" },
                    { 4, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Category_Delete", "CATEGORY_DELETE" },
                    { 3, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Category_Update", "CATEGORY_UPDATE" },
                    { 2, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "Category_Read", "CATEGORY_READ" },
                    { 11, "e654aabb-22f6-44c2-ac8b-189b01d33ebc", "User_Update", "USER_UPDATE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "id", "about_me", "access_failed_count", "avatar", "concurrency_stamp", "email", "email_confirmed", "facebook_link", "first_name", "git_hub_link", "instagram_link", "last_name", "linked_in_link", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "twitter_link", "two_factor_enabled", "user_name", "website_link", "youtube_link" },
                values: new object[,]
                {
                    { 2, null, 0, "Users/defaultUser.png", "a171912d-6895-4bf2-bbc1-5855160d9dde", "editorUser@gmail.com", true, null, "Editor", null, null, "User", null, false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAEAIrXFhINk5oelO9lMZdlQsBPGBQ3m0H2xRcMg25TZoCRLKIOA+BGjL/rQCINCyPGw==", "+9949999999", true, "3FFDA2C7-A349-4902-AC11-6FFAB9969424", null, false, "editorUser", null, null },
                    { 1, null, 0, "Users/defaultUser.png", "c6480f99-28db-420a-8705-d73984f5a321", "adminUser@gmail.com", true, null, "Super Admin", null, null, "User", null, false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAECZ3evZybc2+jwI/rgLZcXLksi70+f95fAFk1btLRTeflu3VRJiZSwRavydlxFEM4w==", "+9949999999", true, "3317689B-4358-4F80-874E-D8B6EAEF0AE4", null, false, "adminUser", null, null },
                    { 3, null, 0, "Users/defaultUser.png", "2684fb06-4389-4e22-b936-c3c359c585a7", "memberUser@gmail.com", true, null, "Member", null, null, "User", null, false, null, "MEMBERUSER@GMAIL.COM", "MEMBERUSER", "AQAAAAEAACcQAAAAEKObRemZ3RdV7kc3K0hpWYmyF2qWSK5plh9i4/xHJcS452PfBCDtIsg5WuooqxGAKQ==", "+9949999999", true, "075E56DF-300D-4AF1-952E-951A18322EE1", null, false, "memberUser", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 19, 1 },
                    { 4, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 17, 2 },
                    { 18, 2 },
                    { 19, 2 },
                    { 5, 2 },
                    { 20, 2 },
                    { 18, 1 },
                    { 16, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 17, 1 },
                    { 8, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 9, 1 },
                    { 21, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                schema: "Identity",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                schema: "Identity",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_comments_post_id",
                table: "Comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_user_id",
                table: "Comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_category_id",
                table: "Posts",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_user_id",
                table: "Posts",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
