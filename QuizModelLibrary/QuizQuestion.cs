namespace QuizModelLibrary
{
    public class QuizQuestion(string question, List<string> correctAnswers, List<string> wrongAnswers)
    {
        public int Id { get; set; }
        public string Question { get; set; } = question;

        public List<string> CorrectAnswers { get; set; } = correctAnswers;

        public List<string> WrongAnswers { get; set; } = wrongAnswers;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string output = "";

            output += $"Question - {Question}\n";

            output += "Correct Answer\n";
            foreach (string options in CorrectAnswers)
            {
                output += $"{options}\n";

            }

            output += $"\nWrong Answers\n";
            foreach (string options in WrongAnswers)
            {
                output += $"{options}\n";

            }

            return output;
        }

        public override bool Equals(object? obj)
        {
            return Id == (obj as QuizQuestion).Id;
        }
    }
}
