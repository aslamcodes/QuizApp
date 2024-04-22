using QuizModelLibrary;

namespace QuizDALLibrary
{
    public class QuizAttemptRepository : IRepository<int, QuizAttempt>
    {
        readonly Dictionary<int, QuizAttempt> _quizAttempts;
        public QuizAttemptRepository()
        {
            _quizAttempts = new Dictionary<int, QuizAttempt>();
        }
        int GenerateId()
        {
            if (_quizAttempts.Count == 0)
                return 1;
            int id = _quizAttempts.Keys.Max();
            return ++id;
        }
        public QuizAttempt? Add(QuizAttempt item)
        {
            if (_quizAttempts.ContainsValue(item))
            {

                return null;
            }
            item.Id = GenerateId();
            _quizAttempts.Add(item.Id, item);
            return item;
        }

        public QuizAttempt Delete(int key)
        {
            if (_quizAttempts.ContainsKey(key))
            {
                var Employee = _quizAttempts[key];
                _quizAttempts.Remove(key);
                return Employee;
            }
            return null;
        }

        public QuizAttempt Get(int key)
        {
            return _quizAttempts.ContainsKey(key) ? _quizAttempts[key] : null;
        }

        public List<QuizAttempt> GetAll()
        {
            if (_quizAttempts.Count == 0)
                return null;
            return _quizAttempts.Values.ToList();
        }

        public QuizAttempt Update(QuizAttempt item)
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
