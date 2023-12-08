using bit.userManager.Models;

namespace bit.userManager.IRepository
{
    public interface IUser
    {
        int addNumber();

        string CreateUser(user model);
        List<user> getUser(user model);
        user updateUser(int id, user model2);
        user deleteUser(int id);
        user getUserId(int id);
    }
}
