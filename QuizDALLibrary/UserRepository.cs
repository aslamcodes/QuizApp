using QuizModelLibrary;

namespace QuizDALLibrary
{
    public class UserRepository : IRepository<int, User>
    {
        readonly Dictionary<int, User> _quizAttempts;
        public UserRepository()
        {
            _quizAttempts = [];
        }
        int GenerateId()
        {
            if (_quizAttempts.Count == 0)
                return 1;
            int id = _quizAttempts.Keys.Max();
            return ++id;
        }
        public User? Add(User item)
        {
            if (_quizAttempts.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _quizAttempts.Add(item.Id, item);
            return item;
        }

        public User Delete(int key)
        {
            if (_quizAttempts.ContainsKey(key))
            {
                var Employee = _quizAttempts[key];
                _quizAttempts.Remove(key);
                return Employee;
            }
            return null;
        }

        public User Get(int key)
        {
            return _quizAttempts.ContainsKey(key) ? _quizAttempts[key] : null;
        }

        public List<User> GetAll()
        {
            if (_quizAttempts.Count == 0)
                return null;
            return _quizAttempts.Values.ToList();
        }

        public User Update(User item)
        {
            if (_quizAttempts.ContainsKey(item.Id))
            {
                _quizAttempts[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
