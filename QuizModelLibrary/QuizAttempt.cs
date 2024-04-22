namespace QuizModelLibrary
{
    public class QuizAttempt(int quizId, int userId)
    {
        public int Id { get; set; }

        public int QuizId { get; set; } = quizId;

        public int UserId { get; set; } = userId;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Id == (obj as QuizAttempt).Id;
        }
    }
}
