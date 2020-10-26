using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendApi.Migrations
{
    public partial class FixedSqRules2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Worksite_Id",
                table: "Worksites",
                nullable: false,
                defaultValueSql: "nextval('\"sq_worksite\"')",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "nextval(\"'sq_worksite'\")");

            migrationBuilder.AlterColumn<short>(
                name: "Stage_Id",
                table: "Stages",
                nullable: false,
                defaultValueSql: "nextval('\"sq_state\"')",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "nextval(\"'sq_state'\")");

            migrationBuilder.AlterColumn<short>(
                name: "Image_Id",
                table: "Images",
                nullable: false,
                defaultValueSql: "nextval('\"sq_image\"')",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "nextval(\"'sq_image'\")");

            migrationBuilder.AlterColumn<short>(
                name: "FlatInfo_Id",
                table: "FlatInfos",
                nullable: false,
                defaultValueSql: "nextval('\"sq_flatinfo\"')",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "nextval(\"'sq_flatinfo'\")");

            migrationBuilder.AlterColumn<short>(
                name: "Category_Id",
                table: "Categories",
                nullable: false,
                defaultValueSql: "nextval('\"sq_category\"')",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "nextval(\"'sq_category'\")");

            migrationBuilder.AlterColumn<short>(
                name: "Campaign_Id",
                table: "Campaigns",
                nullable: false,
                defaultValueSql: "nextval('\"sq_campaign\"')",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "nextval(\"'sq_campaign'\")");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Worksite_Id",
                table: "Worksites",
                type: "smallint",
                nullable: false,
                defaultValueSql: "nextval(\"'sq_worksite'\")",
                oldClrType: typeof(short),
                oldDefaultValueSql: "nextval('\"sq_worksite\"')");

            migrationBuilder.AlterColumn<short>(
                name: "Stage_Id",
                table: "Stages",
                type: "smallint",
                nullable: false,
                defaultValueSql: "nextval(\"'sq_state'\")",
                oldClrType: typeof(short),
                oldDefaultValueSql: "nextval('\"sq_state\"')");

            migrationBuilder.AlterColumn<short>(
                name: "Image_Id",
                table: "Images",
                type: "smallint",
                nullable: false,
                defaultValueSql: "nextval(\"'sq_image'\")",
                oldClrType: typeof(short),
                oldDefaultValueSql: "nextval('\"sq_image\"')");

            migrationBuilder.AlterColumn<short>(
                name: "FlatInfo_Id",
                table: "FlatInfos",
                type: "smallint",
                nullable: false,
                defaultValueSql: "nextval(\"'sq_flatinfo'\")",
                oldClrType: typeof(short),
                oldDefaultValueSql: "nextval('\"sq_flatinfo\"')");

            migrationBuilder.AlterColumn<short>(
                name: "Category_Id",
                table: "Categories",
                type: "smallint",
                nullable: false,
                defaultValueSql: "nextval(\"'sq_category'\")",
                oldClrType: typeof(short),
                oldDefaultValueSql: "nextval('\"sq_category\"')");

            migrationBuilder.AlterColumn<short>(
                name: "Campaign_Id",
                table: "Campaigns",
                type: "smallint",
                nullable: false,
                defaultValueSql: "nextval(\"'sq_campaign'\")",
                oldClrType: typeof(short),
                oldDefaultValueSql: "nextval('\"sq_campaign\"')");
        }
    }
}
