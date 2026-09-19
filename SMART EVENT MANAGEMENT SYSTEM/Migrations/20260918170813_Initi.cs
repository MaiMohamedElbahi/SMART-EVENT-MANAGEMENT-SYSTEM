using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SMART_EVENT_MANAGEMENT_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class Initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeeId);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.OrganizerId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "OrganizerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AttendeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "AttendeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "AttendeeId", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "mai.mohamed@example.com", "Mai Mohamed", "+201000111222" },
                    { 2, "youssef.ahmed@example.com", "Youssef Ahmed", "+201011222333" },
                    { 3, "mariam.khaled@example.com", "Mariam Khaled", "+201022333444" },
                    { 4, "karim.mostafa@example.com", "Karim Mostafa", "+201033444555" },
                    { 5, "lina.omar@example.com", "Lina Omar", "+201044555666" },
                    { 6, "adam.hassan@example.com", "Adam Hassan", "+201055666777" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "OrganizerId", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed.hassan@example.com", "Ahmed Hassan", "+201001234567" },
                    { 2, "sara.mohamed@example.com", "Sara Mohamed", "+201112345678" },
                    { 3, "omar.ali@example.com", "Omar Ali", "+201223456789" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "VenueId", "Capacity", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 5000, "Nasr City, Cairo", "Cairo Convention Center" },
                    { 2, 2500, "Alexandria, Egypt", "Alexandria Cultural Hall" },
                    { 3, 1000, "Maadi, Cairo", "Nile Conference Hall" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Capacity", "Category", "Description", "EndTime", "EventDate", "OrganizerId", "StartTime", "Title", "VenueId" },
                values: new object[,]
                {
                    { 1, 3000, "Technology", "A conference about technology and innovation.", new TimeSpan(0, 16, 0, 0, 0), new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), "Tech Innovation Summit", 1 },
                    { 2, 1500, "Business", "A forum for young business leaders.", new TimeSpan(0, 17, 0, 0, 0), new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 11, 0, 0, 0), "Business Leadership Forum", 2 },
                    { 3, 500, "Marketing", "A practical workshop about digital marketing.", new TimeSpan(0, 14, 0, 0, 0), new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 9, 0, 0, 0), "Digital Marketing Workshop", 3 },
                    { 4, 2000, "Technology", "Exploring artificial intelligence and future technologies.", new TimeSpan(0, 15, 0, 0, 0), new DateTime(2026, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), "AI and Future Technologies", 2 },
                    { 5, 800, "Entrepreneurship", "An event connecting entrepreneurs and startups.", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 12, 0, 0, 0), "Entrepreneurship Meetup", 1 }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationId", "AttendeeId", "EventId", "RegistrationDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 2, 2, 1, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 3, 3, 2, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 4, 4, 2, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 5, 1, 3, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 6, 5, 4, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 7, 6, 5, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 8, 3, 4, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Email",
                table: "Attendees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_Email",
                table: "Organizers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AttendeeId",
                table: "Registrations",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId_AttendeeId",
                table: "Registrations",
                columns: new[] { "EventId", "AttendeeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
