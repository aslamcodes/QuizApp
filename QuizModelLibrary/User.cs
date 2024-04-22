namespace QuizModelLibrary
{
    public class User(string name, string password)
    {

        public int Id { get; set; }

        public string Name { get; set; } = name;

        public string Password { get; set; } = password;

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
            return Id == (obj as User).Id;
        }
    }
}
