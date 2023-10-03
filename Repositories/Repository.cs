using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using ShoppingCart.Model;
using System.Data;

namespace ShoppingCart.Repositories
{
    public class Repository : IRepository
    {
        private IDbConnection db;
        public Repository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("Connection"));
        }
        public UserReg Add(UserReg reg)
        {
            var Name = db.Insert(reg);
            reg.Username = Name.ToString();
            return reg;
            
        }

        public List<UserLogin> GetFeilds()
        {
            var sql = "Select Username,Password from userRegs";
            return db.Query<UserLogin>(sql).ToList();
            //return userLogins;
        }
    }
}
