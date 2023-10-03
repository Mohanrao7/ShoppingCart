using ShoppingCart.Model;

namespace ShoppingCart.Repositories
{
    public interface IRepository
    {
        UserReg Add(UserReg reg);
        List<UserLogin> GetFeilds();
    }
}
