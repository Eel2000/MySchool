using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchool.Data.Migrations
{
    public partial class __init__ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignationCours",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursID = table.Column<int>(nullable: false),
                    EnseignantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignationCours", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionID);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentID);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    EnseignantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    OptionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.EnseignantID);
                    table.ForeignKey(
                        name: "FK_Enseignants_Options_OptionID",
                        column: x => x.OptionID,
                        principalTable: "Options",
                        principalColumn: "OptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Derogations",
                columns: table => new
                {
                    DerogationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(nullable: false),
                    Obj = table.Column<string>(nullable: false),
                    Libele = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derogations", x => x.DerogationID);
                    table.ForeignKey(
                        name: "FK_Derogations_Parents_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parents",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enfants",
                columns: table => new
                {
                    EnfantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    ParentID = table.Column<int>(nullable: false),
                    OptionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfants", x => x.EnfantID);
                    table.ForeignKey(
                        name: "FK_Enfants_Options_OptionID",
                        column: x => x.OptionID,
                        principalTable: "Options",
                        principalColumn: "OptionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enfants_Parents_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parents",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CoursID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionID = table.Column<int>(nullable: false),
                    EnseignantID = table.Column<int>(nullable: false),
                    DesignationCours = table.Column<string>(maxLength: 30, nullable: false),
                    VolumeHoraire = table.Column<string>(maxLength: 5, nullable: false),
                    Statu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CoursID);
                    table.ForeignKey(
                        name: "FK_Cours_Enseignants_EnseignantID",
                        column: x => x.EnseignantID,
                        principalTable: "Enseignants",
                        principalColumn: "EnseignantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cours_Options_OptionID",
                        column: x => x.OptionID,
                        principalTable: "Options",
                        principalColumn: "OptionID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Punitions",
                columns: table => new
                {
                    PunitionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnfantID = table.Column<int>(nullable: false),
                    Cause = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EnfantsEnfantID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punitions", x => x.PunitionID);
                    table.ForeignKey(
                        name: "FK_Punitions_Enfants_EnfantsEnfantID",
                        column: x => x.EnfantsEnfantID,
                        principalTable: "Enfants",
                        principalColumn: "EnfantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Traveaux",
                columns: table => new
                {
                    TravailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    EnfantsEnfantID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traveaux", x => x.TravailID);
                    table.ForeignKey(
                        name: "FK_Traveaux_Cours_CoursID",
                        column: x => x.CoursID,
                        principalTable: "Cours",
                        principalColumn: "CoursID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traveaux_Enfants_EnfantsEnfantID",
                        column: x => x.EnfantsEnfantID,
                        principalTable: "Enfants",
                        principalColumn: "EnfantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EnseignantID",
                table: "Cours",
                column: "EnseignantID");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_OptionID",
                table: "Cours",
                column: "OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Derogations_ParentID",
                table: "Derogations",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_OptionID",
                table: "Enfants",
                column: "OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_ParentID",
                table: "Enfants",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_OptionID",
                table: "Enseignants",
                column: "OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Punitions_EnfantsEnfantID",
                table: "Punitions",
                column: "EnfantsEnfantID");

            migrationBuilder.CreateIndex(
                name: "IX_Traveaux_CoursID",
                table: "Traveaux",
                column: "CoursID");

            migrationBuilder.CreateIndex(
                name: "IX_Traveaux_EnfantsEnfantID",
                table: "Traveaux",
                column: "EnfantsEnfantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignationCours");

            migrationBuilder.DropTable(
                name: "Derogations");

            migrationBuilder.DropTable(
                name: "Punitions");

            migrationBuilder.DropTable(
                name: "Traveaux");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Enfants");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Options");
        }
    }
}
