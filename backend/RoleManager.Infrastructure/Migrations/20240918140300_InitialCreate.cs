using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    History = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CharacterIds = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FactionIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomainIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestIds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    DomainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocationIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactionIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    History = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Objectives = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.DomainId);
                    table.ForeignKey(
                        name: "FK_Domains_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    QuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.QuestId);
                    table.ForeignKey(
                        name: "FK_Quests_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DomainId = table.Column<int>(type: "int", nullable: true),
                    CharacterIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId");
                });

            migrationBuilder.CreateTable(
                name: "QuestStages",
                columns: table => new
                {
                    StageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    QuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestStages", x => x.StageId);
                    table.ForeignKey(
                        name: "FK_QuestStages_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "QuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAlly",
                columns: table => new
                {
                    AllyId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAlly", x => new { x.AllyId, x.CharacterId });
                });

            migrationBuilder.CreateTable(
                name: "CharacterRival",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    RivalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterRival", x => new { x.CharacterId, x.RivalId });
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Inventory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proficiencies = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Backstory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Motivations = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PersonalityTraits = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhysicalDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quirks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: true),
                    Dexterity = table.Column<int>(type: "int", nullable: true),
                    Constitution = table.Column<int>(type: "int", nullable: true),
                    Intelligence = table.Column<int>(type: "int", nullable: true),
                    Wisdom = table.Column<int>(type: "int", nullable: true),
                    Charisma = table.Column<int>(type: "int", nullable: true),
                    HitPoints = table.Column<int>(type: "int", nullable: true),
                    ArmorClass = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId");
                    table.ForeignKey(
                        name: "FK_Characters_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    FactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LeaderId = table.Column<int>(type: "int", nullable: true),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    History = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Objectives = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    DomainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.FactionId);
                    table.ForeignKey(
                        name: "FK_Factions_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId");
                    table.ForeignKey(
                        name: "FK_Factions_Characters_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factions_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId");
                });

            migrationBuilder.CreateTable(
                name: "FactionAlly",
                columns: table => new
                {
                    AllyId = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionAlly", x => new { x.AllyId, x.FactionId });
                    table.ForeignKey(
                        name: "FK_FactionAlly_Factions_AllyId",
                        column: x => x.AllyId,
                        principalTable: "Factions",
                        principalColumn: "FactionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactionAlly_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "FactionId");
                });

            migrationBuilder.CreateTable(
                name: "FactionEnemy",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionEnemy", x => new { x.EnemyId, x.FactionId });
                    table.ForeignKey(
                        name: "FK_FactionEnemy_Factions_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Factions",
                        principalColumn: "FactionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactionEnemy_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "FactionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAlly_CharacterId",
                table: "CharacterAlly",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRival_RivalId",
                table: "CharacterRival",
                column: "RivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CampaignId",
                table: "Characters",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_DomainId",
                table: "Characters",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FactionId",
                table: "Characters",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_LocationId",
                table: "Characters",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_CampaignId",
                table: "Domains",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionAlly_FactionId",
                table: "FactionAlly",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionEnemy_FactionId",
                table: "FactionEnemy",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_CampaignId",
                table: "Factions",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_DomainId",
                table: "Factions",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_LeaderId",
                table: "Factions",
                column: "LeaderId",
                unique: true,
                filter: "[LeaderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CampaignId",
                table: "Locations",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DomainId",
                table: "Locations",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_CampaignId",
                table: "Quests",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestStages_QuestId",
                table: "QuestStages",
                column: "QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAlly_Characters_AllyId",
                table: "CharacterAlly",
                column: "AllyId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAlly_Characters_CharacterId",
                table: "CharacterAlly",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRival_Characters_CharacterId",
                table: "CharacterRival",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterRival_Characters_RivalId",
                table: "CharacterRival",
                column: "RivalId",
                principalTable: "Characters",
                principalColumn: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Factions_FactionId",
                table: "Characters",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "FactionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factions_Characters_LeaderId",
                table: "Factions");

            migrationBuilder.DropTable(
                name: "CharacterAlly");

            migrationBuilder.DropTable(
                name: "CharacterRival");

            migrationBuilder.DropTable(
                name: "FactionAlly");

            migrationBuilder.DropTable(
                name: "FactionEnemy");

            migrationBuilder.DropTable(
                name: "QuestStages");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
