using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGE.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    IdDisciplina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ementa = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.IdDisciplina);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    UF = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    IdProfessor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.IdProfessor);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    IdTurma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Turno = table.Column<string>(nullable: false),
                    Sala = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.IdTurma);
                });

            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    IdEscola = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEndereco = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.IdEscola);
                    table.ForeignKey(
                        name: "FK_Escolas_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorDisciplinas",
                columns: table => new
                {
                    IdProfessor = table.Column<int>(nullable: false),
                    IdDisciplina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorDisciplinas", x => new { x.IdDisciplina, x.IdProfessor });
                    table.ForeignKey(
                        name: "FK_ProfessorDisciplinas_Disciplinas_IdDisciplina",
                        column: x => x.IdDisciplina,
                        principalTable: "Disciplinas",
                        principalColumn: "IdDisciplina",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorDisciplinas_Professores_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "Professores",
                        principalColumn: "IdProfessor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisciplinas",
                columns: table => new
                {
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdTurma = table.Column<int>(nullable: false),
                    IdDisciplina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaDisciplinas", x => new { x.IdTurma, x.IdDisciplina });
                    table.ForeignKey(
                        name: "FK_TurmaDisciplinas_Disciplinas_IdDisciplina",
                        column: x => x.IdDisciplina,
                        principalTable: "Disciplinas",
                        principalColumn: "IdDisciplina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TurmaDisciplinas_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEndereco = table.Column<int>(nullable: false),
                    IdTurma = table.Column<int>(nullable: false),
                    IdEscola = table.Column<int>(nullable: false),
                    Matricula = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Alunos_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alunos_Escolas_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escolas",
                        principalColumn: "IdEscola",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EscolaTurmas",
                columns: table => new
                {
                    IdTurma = table.Column<int>(nullable: false),
                    IdEscola = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscolaTurmas", x => new { x.IdEscola, x.IdTurma });
                    table.ForeignKey(
                        name: "FK_EscolaTurmas_Escolas_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escolas",
                        principalColumn: "IdEscola",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EscolaTurmas_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trabalhas",
                columns: table => new
                {
                    Adimissao = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    IdEscola = table.Column<int>(nullable: false),
                    IdProfessor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabalhas", x => new { x.IdEscola, x.IdProfessor });
                    table.ForeignKey(
                        name: "FK_Trabalhas_Escolas_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escolas",
                        principalColumn: "IdEscola",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trabalhas_Professores_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "Professores",
                        principalColumn: "IdProfessor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdEndereco",
                table: "Alunos",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdEscola",
                table: "Alunos",
                column: "IdEscola");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdTurma",
                table: "Alunos",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Escolas_IdEndereco",
                table: "Escolas",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_EscolaTurmas_IdTurma",
                table: "EscolaTurmas",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorDisciplinas_IdProfessor",
                table: "ProfessorDisciplinas",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhas_IdProfessor",
                table: "Trabalhas",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplinas_IdDisciplina",
                table: "TurmaDisciplinas",
                column: "IdDisciplina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "EscolaTurmas");

            migrationBuilder.DropTable(
                name: "ProfessorDisciplinas");

            migrationBuilder.DropTable(
                name: "Trabalhas");

            migrationBuilder.DropTable(
                name: "TurmaDisciplinas");

            migrationBuilder.DropTable(
                name: "Escolas");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
