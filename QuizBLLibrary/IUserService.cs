using QuizModelLibrary;

namespace QuizBLLibrary
{
    internal interface IUserService
    {
        int AddUser(User user);

        User GetUserById(int id);

        User ChangeUserName(int id, string userNewName);

        User DeleteUser(int id);

        public User GetUserByUserName(string username);


    }
}