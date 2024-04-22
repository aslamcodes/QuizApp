using QuizModelLibrary;

namespace QuizBLLibrary
{
    public interface IQuizService
    {

        int AddQuiz(Quiz quiz);

        Quiz GetQuizById(int id);

        List<Quiz> GetAllQuizzes();

        Quiz ChangeQuizTitle(int quizId, string quizNewTitle);

        Quiz DeleteQuiz(int quizID);
    }
}
