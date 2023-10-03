using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               Create proc sp_AddCredentials
               @Username varchar(Max),
               @Password varchar(Max),
               @Gender Varchar(Max),
               @PhoneNumber varchar(Max),
               @State varchar(Max)
               As
               Begin
                Insert into userRegs (Username,Password,Gender,PhoneNumber,State) values(@Username, @Password, @Gender, @PhoneNumber, @State);
               End
               Go
            ");
            migrationBuilder.Sql(@"
               Create proc sp_GetCredentials
               As
               Begin
                 Select Username,Password from userRegs
               End
               Go
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
