namespace QuizModelLibrary
{
    public class QuizAttempt(int quizId, int userId, int score, List<QuizQuestion> correctlyAnswered, List<QuizQuestion> wrongQuestions)
    {
        public int Id { get; set; }

        public int QuizId { get; set; } = quizId;

        public int UserId { get; set; } = userId;

        public int Score { get; set; } = score;

        public List<QuizQuestion> CorrectlyAnswered { get; set; } = correctlyAnswered;

        public List<QuizQuestion> WronglyAnswered { get; set; } = wrongQuestions;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string output = $"Attempt ID - {Id}\nQuiz ID {QuizId}\nUser Id {UserId}\nScore {Score}\n";

            output += "Correctly Answered\n";

            foreach (var question in CorrectlyAnswered)
            {
                output += question + "\n";
            }

            output += "Wrongly Answered\n";

            foreach (var question in WronglyAnswered)
            {
                output += question + "\n";
            }

            return output;
        }

        public override bool Equals(object? obj)
        {
            return Id == (obj as QuizAttempt).Id;
        }
    }
}
