using QuizBLLibrary;
using QuizModelLibrary;

namespace QuizApp
{
    public class Program
    {
        private readonly QuizService _quizService;

        Program()
        {
            _quizService = new QuizService();
        }

        public static int GetIntegerInputFromConsole(string textToDisplay)
        {
            int output = 0;
            while (!int.TryParse(Console.ReadLine(), out output))
            {
                Console.WriteLine("Invalid Format");
            }
            return output;
        }

        public void PrintAllQuizzes()
        {
            foreach (Quiz quiz in GetAllQuizzes())
            {
                Console.WriteLine($"{quiz.Id} - {quiz}\n");
            }
        }
        public void AddQuiz()
        {
            try
            {
                var quiz = new Quiz("Hello", "Hey", []);

                _quizService.AddQuiz(quiz);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong");
            }
        }

        public void RemoveQuiz()
        {
            PrintAllQuizzes();

            int id = GetIntegerInputFromConsole("Select a Quiz id");

            var deletedQuiz = _quizService.DeleteQuiz(id);

            Console.WriteLine($"Deleted {deletedQuiz.Title}");
        }

        public void ChangeQuizTitle()
        {
            try
            {
                PrintAllQuizzes();
                int id = GetIntegerInputFromConsole("Select Quiz Id");
                Console.WriteLine("Enter new Name");
                string newQuizTitle = Console.ReadLine() ?? string.Empty;
                var quiz = _quizService.ChangeQuizTitle(id, newQuizTitle);
                Console.WriteLine($"Updated Quiz name to {quiz.Title}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public List<Quiz> GetAllQuizzes()
        {
            var quizzes = _quizService.GetAllQuizzes();


            return quizzes;
        }

        static void Main(string[] args)
        {
            Program program = new();

            int choice = 0;

            Console.WriteLine("Welcome to Presidio | GenSpark QuizMS");

            while (choice != -1)
            {

                Console.WriteLine("\nMenu\n1. Create a new Quiz\n2. List all Quizzes\n3. Remove Quiz\n4. Change Quiz Title");

                Console.WriteLine("Enter Choice");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Format");
                }

                switch (choice)
                {
                    case 1:
                        program.AddQuiz();
                        break;

                    case 2:
                        program.PrintAllQuizzes();
                        break;

                    case 3:
                        program.RemoveQuiz();
                        break;

                    case 4:
                        program.ChangeQuizTitle();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                Console.WriteLine("Press a key to continue");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
