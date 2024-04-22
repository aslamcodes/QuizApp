using QuizDALLibrary;
using QuizModelLibrary;

namespace QuizBLLibrary
{
    public class QuizService : IQuizService
    {
        private readonly QuizRepository _quizRepository;
        public QuizService()
        {
            _quizRepository = new QuizRepository();
        }
        public int AddQuiz(Quiz quiz)
        {
            var e = _quizRepository.Add(quiz);

            if (e != null) return e.Id;

            throw new DuplicateQuizException();
        }

        public Quiz ChangeQuizTitle(int quizId, string quizNewTitle)
        {

            var quiz = GetQuizById(quizId);
            quiz.Title = quizNewTitle;
            var newQuiz = _quizRepository.Update(quiz);
            if (newQuiz != null)
            {
                return newQuiz;
            }
            throw new QuizNotFoundException();
        }

        public Quiz DeleteQuiz(int quizID)
        {
            var quiz = _quizRepository.Delete(quizID);

            return quiz ?? throw new QuizNotFoundException();
        }

        public List<Quiz> GetAllQuizzes()
        {
            var quizzes = _quizRepository.GetAll();

            return quizzes ?? throw new QuizNotFoundException();
        }

        public Quiz GetQuizById(int id)
        {
            var quiz = _quizRepository.Get(id);

            if (quiz != null) return quiz;

            throw new QuizNotFoundException();
        }
    }
}
