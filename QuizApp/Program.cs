using QuizBLLibrary;
using QuizModelLibrary;

namespace QuizApp
{
    public class Program
    {
        private readonly QuizService _quizService;
        private readonly UserService _userService;
        private readonly QuizAttemptService _quizAttemptService;
        //private readonly UserSerzzz[] ;
        //private readonly UserService _userService;
        private User LoggedInUser;
        Program()
        {
            _quizService = new QuizService();
            _userService = new UserService();
            _quizAttemptService = new QuizAttemptService();

            User user1 = new("Aslam", "123");

            User user2 = new("Mechabot", "123");

            _userService.AddUser(user1);
            _userService.AddUser(user2);

            LoggedInUser = user1;
        }

        public static int GetIntegerInputFromConsole(string textToDisplay)
        {
            Console.WriteLine(textToDisplay);
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
        public static List<QuizQuestion> GenerateQuizQuestions(int numberOfQuestions)
        {
            List<QuizQuestion> quizQuestions = [];

            while (numberOfQuestions > 0)
            {
                Console.WriteLine("Enter the Question");
                string question = Console.ReadLine() ?? string.Empty;

                //int correctAnswerCount = 1;
                List<string> correctAnswers = [];

                Console.WriteLine("Enter correct answer");
                correctAnswers.Add(Console.ReadLine() ?? string.Empty);

                //correctAnswerCount = GetIntegerInputFromConsole("Enter correct answers count"); ;
                int wrongAnswerCount = GetIntegerInputFromConsole("Enter wrong answers count");
                List<string> wrongAnswers = [];
                while (wrongAnswerCount > 0)
                {
                    Console.WriteLine($"Enter Wrong Answer ({wrongAnswerCount} more): ");
                    wrongAnswers.Add(Console.ReadLine() ?? string.Empty);
                    wrongAnswerCount--;
                }

                QuizQuestion quizQuestion = new QuizQuestion(question, correctAnswers, wrongAnswers);
                quizQuestions.Add(quizQuestion);
                numberOfQuestions--;
            }

            return quizQuestions;

        }
        public void AddQuiz()
        {
            try
            {
                Console.WriteLine("Enter Title");
                string title = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter Description");
                string description = Console.ReadLine() ?? string.Empty;
                int numberOfQuestions = GetIntegerInputFromConsole("Enter number of questions");

                var quizQuestions = GenerateQuizQuestions(numberOfQuestions);

                var quiz = new Quiz(title, description, quizQuestions, LoggedInUser);

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
        public void Login()
        {
            Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();
            try
            {
                var User = _userService.GetUserByUserName(username);
                if (password == User.Password)
                {
                    LoggedInUser = User;
                }
            }
            catch (Exception)
            {


            }


        }
        public void QuizManagement()
        {
            int choice = 0;

            while (choice != -1)
            {

                Console.WriteLine("\nMenu\n1. Create a new Quiz\n2. List all your Quizzes\n3. Remove Quiz\n4. Change Quiz Title");

                Console.WriteLine("Enter Choice");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Format");
                }

                switch (choice)
                {
                    case 1:
                        AddQuiz();
                        break;

                    case 2:
                        PrintAllQuizzes();
                        break;

                    case 3:
                        RemoveQuiz();
                        break;

                    case 4:
                        ChangeQuizTitle();
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
        public void TakeQuiz()
        {

        }
        static void Main(string[] args)
        {
            Program program = new();

            Console.WriteLine("Welcome to Presidio | GenSpark QuizMS");

            int choice = 0;

            program.Login();

            while (choice != -1)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Manage your Quizzes");
                Console.WriteLine("2. Take Quiz!");
                Console.WriteLine("3. Review Your last Quiz");

                choice = GetIntegerInputFromConsole("Enter a Choice");

                switch (choice)
                {
                    case 1:
                        program.QuizManagement();
                        break;
                }

            }

        }
    }
}
