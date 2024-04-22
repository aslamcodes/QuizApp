using QuizModelLibrary;

namespace QuizBLLibrary
{
    public interface IQuizAttemptService
    {
        int AddQuizAttempt(QuizAttempt quizAttempt);

        QuizAttempt GetQuizAttemptByID(int id);


        QuizAttempt DeleteQuizAttempt(int id);
    }
}