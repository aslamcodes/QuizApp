using QuizDALLibrary;
using QuizModelLibrary;

namespace QuizBLLibrary
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepo;
        public UserService()
        {
            _userRepo = new UserRepository();
        }
        public int AddUser(User user)
        {
            var addedUser = _userRepo.Add(user);
            if (addedUser != null)
            {
                return addedUser.Id;
            }
            throw new DuplicateUserException();
        }

        public User ChangeUserName(int id, string userNewName)
        {
            throw new NotImplementedException();
        }

        public User DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserName(string username)
        {
            foreach (User user in _userRepo.GetAll())
            {
                if (user.Name == username) return user;
            }

            throw new UserNotFoundException();
        }
    }
}
