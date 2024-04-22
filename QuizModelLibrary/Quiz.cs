namespace QuizModelLibrary
{
    public class Quiz(string title, string description, List<QuizQuestion> quizQuestions, User createdBy)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;

        public string Description { get; set; } = description;
        public List<QuizQuestion> QuizQuestions { get; set; } = quizQuestions;

        public User CreatedBy { get; set; } = createdBy;

        public bool isPublished = false;

        public override string ToString()
        {
            return $"Id {Id}\nTitle {Title}\nDescription {Description}";
        }

        public override bool Equals(object? obj)
        {
            return Id == (obj as Quiz).Id;
        }
    }
}
