namespace QuizModelLibrary
{
    public class Quiz(string title, string description, List<QuizQuestion> quizQuestions)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;

        public string Description { get; set; } = description;
        public List<QuizQuestion> QuizQuestions { get; set; } = quizQuestions;

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Id == (obj as Quiz).Id;
        }
    }
}
