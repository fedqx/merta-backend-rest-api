using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<short>(
                name: "sq_campaign");

            migrationBuilder.CreateSequence<short>(
                name: "sq_category");

            migrationBuilder.CreateSequence<short>(
                name: "sq_flatinfo");

            migrationBuilder.CreateSequence<short>(
                name: "sq_image");

            migrationBuilder.CreateSequence<short>(
                name: "sq_stage");

            migrationBuilder.CreateSequence<short>(
                name: "sq_worksite");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_Id = table.Column<short>(nullable: false, defaultValueSql: "nextval(\"'sq_category'\")"),
                    Category_Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Stage_Id = table.Column<short>(nullable: false, defaultValueSql: "nextval(\"'sq_state'\")"),
                    Stage_Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Stage_Id);
                });

            migrationBuilder.CreateTable(
                name: "Worksites",
                columns: table => new
                {
                    Worksite_Id = table.Column<short>(nullable: false, defaultValueSql: "nextval(\"'sq_worksite'\")"),
                    Worksite_Tag = table.Column<string>(nullable: true),
                    Worksite_City = table.Column<string>(nullable: true),
                    Worksite_Adress = table.Column<string>(nullable: true),
                    Worksite_SDate = table.Column<DateTime>(nullable: false),
                    Worksite_FDate = table.Column<DateTime>(nullable: false),
                    WorksiteStage_Id = table.Column<short>(nullable: false),
                    WorksiteCategory_Id = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worksites", x => x.Worksite_Id);
                    table.ForeignKey(
                        name: "FK_Worksites_Categories_WorksiteCategory_Id",
                        column: x => x.WorksiteCategory_Id,
                        principalTable: "Categories",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worksites_Stages_WorksiteStage_Id",
                        column: x => x.WorksiteStage_Id,
                        principalTable: "Stages",
                        principalColumn: "Stage_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Campaign_Id = table.Column<short>(nullable: false, defaultValueSql: "nextval(\"'sq_campaign'\")"),
                    Campaign_Tag = table.Column<string>(nullable: true),
                    Campaign_FDate = table.Column<DateTime>(nullable: false),
                    Campaign_Stage = table.Column<bool>(nullable: false, defaultValue: true),
                    Campaign_ImageUrl = table.Column<string>(nullable: true),
                    CampaignWorksite_Id = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Campaign_Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Worksites_CampaignWorksite_Id",
                        column: x => x.CampaignWorksite_Id,
                        principalTable: "Worksites",
                        principalColumn: "Worksite_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlatInfos",
                columns: table => new
                {
                    FlatInfo_Id = table.Column<short>(nullable: false, defaultValueSql: "nextval(\"'sq_flatinfo'\")"),
                    FlatInfo_Apartment = table.Column<string>(nullable: true),
                    FlatInfo_Room = table.Column<string>(nullable: true),
                    FlatInfo_Size = table.Column<string>(nullable: true),
                    FlatInfo_Front = table.Column<string>(nullable: true),
                    FlatInfoWorksite_Id = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatInfos", x => x.FlatInfo_Id);
                    table.ForeignKey(
                        name: "FK_FlatInfos_Worksites_FlatInfoWorksite_Id",
                        column: x => x.FlatInfoWorksite_Id,
                        principalTable: "Worksites",
                        principalColumn: "Worksite_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Image_Id = table.Column<short>(nullable: false, defaultValueSql: "nextval(\"'sq_image'\")"),
                    Image_Url = table.Column<string>(nullable: true),
                    ImageRaw_Url = table.Column<string>(nullable: true),
                    ImageWorksite_Id = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Image_Id);
                    table.ForeignKey(
                        name: "FK_Images_Worksites_ImageWorksite_Id",
                        column: x => x.ImageWorksite_Id,
                        principalTable: "Worksites",
                        principalColumn: "Worksite_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CampaignWorksite_Id",
                table: "Campaigns",
                column: "CampaignWorksite_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FlatInfos_FlatInfoWorksite_Id",
                table: "FlatInfos",
                column: "FlatInfoWorksite_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageWorksite_Id",
                table: "Images",
                column: "ImageWorksite_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Worksites_WorksiteCategory_Id",
                table: "Worksites",
                column: "WorksiteCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Worksites_WorksiteStage_Id",
                table: "Worksites",
                column: "WorksiteStage_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "FlatInfos");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Worksites");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropSequence(
                name: "sq_campaign");

            migrationBuilder.DropSequence(
                name: "sq_category");

            migrationBuilder.DropSequence(
                name: "sq_flatinfo");

            migrationBuilder.DropSequence(
                name: "sq_image");

            migrationBuilder.DropSequence(
                name: "sq_stage");

            migrationBuilder.DropSequence(
                name: "sq_worksite");
        }
    }
}
