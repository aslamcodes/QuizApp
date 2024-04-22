namespace QuizModelLibrary
{
    public record class QuizQuestion(string Question, List<string> CorrectAnswers, List<string> WrongAnswers)
    {
    }
}
