using QuizModelLibrary;

namespace QuizDALLibrary
{
    public class QuizRepository : IRepository<int, Quiz>
    {
        readonly Dictionary<int, Quiz> _quizzes;

        public QuizRepository()
        {
            _quizzes = [];
        }

        int GenerateId()
        {
            if (_quizzes.Count == 0)
                return 1;
            // Research more about this
            int id = _quizzes.Keys.Max();
            return ++id;
        }

        public Quiz? Add(Quiz item)
        {
            if (_quizzes.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();

            _quizzes.Add(item.Id, item);

            return item;
        }

        public Quiz? Delete(int key)
        {
            if (_quizzes.ContainsKey(key))
            {
                var quiz = _quizzes[key];
                _quizzes.Remove(key);
                return quiz;
            }
            return null;
        }

        public Quiz? Get(int key)
        {
            return _quizzes.ContainsKey(key) ? _quizzes[key] : null;
        }

        public List<Quiz> GetAll()
        {
            if (_quizzes.Count == 0)
                return null;
            return _quizzes.Values.ToList();
        }

        public Quiz? Update(Quiz item)
        {
            if (_quizzes.ContainsKey(item.Id))
            {
                _quizzes[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
