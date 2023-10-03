using Dapper;
using Microsoft.Data.SqlClient;
using ShoppingCart.Model;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShoppingCart.Repositories
{
    public class RepositorySp : IRepository
    {
        private IDbConnection db;
        public RepositorySp(IConfiguration configuration)
        {
            this.db= new SqlConnection(configuration.GetConnectionString("Connection"));
        }
        public UserReg Add(UserReg reg)
        {
            var Param = new DynamicParameters();
            
            Param.Add("@Username", reg.Username);
            Param.Add("@Password", reg.Password);
            Param.Add("@Gender", reg.Gender);
            Param.Add("@PhoneNumber", reg.PhoneNumber);
            Param.Add("@State", reg.State);
            this.db.Execute("sp_AddCredentials", Param, commandType: CommandType.StoredProcedure);
       
            return reg;
        }

        public List<UserLogin> GetFeilds()
        {
            return db.Query<UserLogin>("sp_GetCredentials", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
