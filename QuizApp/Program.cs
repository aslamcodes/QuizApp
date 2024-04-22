namespace QuizApp
{
    public class Program
    {

        public static void AddQuiz()
        {
            Console.Write("Hello");
        }

        static void Main(string[] args)
        {
            List<(string, Action)> Funcions = [("Add", AddQuiz)];

            var UI = new MenuUI(["Arithmetic Calculator"], Funcions);

            UI.Start();
        }
    }
}
