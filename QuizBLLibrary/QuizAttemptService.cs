using QuizDALLibrary;
using QuizModelLibrary;

namespace QuizBLLibrary
{
    public class QuizAttemptService : IQuizAttemptService
    {
        private readonly QuizAttemptRepository _quizAttemptRepo;

        public QuizAttemptService()
        {
            this._quizAttemptRepo = new QuizAttemptRepository();
        }
        public int AddQuizAttempt(QuizAttempt quizAttempt)
        {
            var attempt = _quizAttemptRepo.Add(quizAttempt);

            if (attempt != null)
            {
                return attempt.Id;
            }
            //todo define a custom exception here
            throw new Exception("Cannot add the repository, probably duplication");
        }

        public QuizAttempt DeleteQuizAttempt(int id)
        {
            throw new NotImplementedException();
        }

        public QuizAttempt GetQuizAttemptByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuizAttempt> GetAllQuizAttemptsForUser(User user)
        {
            var userAttempts = from attempts in _quizAttemptRepo.GetAll() where attempts.UserId == user.Id select attempts;

            // todo create new exception
            if (userAttempts == null) throw new Exception("No Attempts Found");

            return userAttempts.ToList();
        }
    }
}