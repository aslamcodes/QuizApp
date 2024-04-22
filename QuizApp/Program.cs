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
        public void PrintAllQuizzes(bool onlyUserQuiz)
        {
            try
            {
                List<Quiz> quizzes;
                if (onlyUserQuiz)
                {
                    quizzes = _quizService.GetAllCreatedQuizzesForUser(LoggedInUser.Id);
                }
                else
                {
                    quizzes = _quizService.GetAllQuizzes();
                }

                foreach (Quiz quiz in quizzes)
                {
                    Console.WriteLine(quiz);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No Quizzes created!");
            }

        }

        public static void WaitUntilAnyKeyPress()
        {
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            Console.Clear();
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
            PrintAllQuizzes(true);

            int id = GetIntegerInputFromConsole("Select a Quiz id");

            var deletedQuiz = _quizService.DeleteQuiz(id);

            Console.WriteLine($"Deleted {deletedQuiz.Title}");
        }
        public void ChangeQuizTitle()
        {
            try
            {
                PrintAllQuizzes(true);
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
            LoggedInUser = null;
            User? user = null;
            while (user == null || LoggedInUser == null)
            {
                try
                {
                    Console.WriteLine("Enter your username");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter the password");
                    string password = Console.ReadLine();

                    user = _userService.GetUserByUserName(username);
                    if (password == user.Password)
                    {
                        LoggedInUser = user;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Password");
                        WaitUntilAnyKeyPress();
                    }
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Creds, please try again!");

                }
            }


        }
        public void QuizManagement()
        {
            int choice = 0;

            while (choice != -1)
            {

                Console.WriteLine("Menu\n1. Create a new Quiz\n2. List all your Quizzes\n3. Remove Quiz\n4. Change Quiz Title\n5. Publish your Quizzes\n-1. Exit Quiz Management");

                choice = GetIntegerInputFromConsole("Enter Choice");

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddQuiz();
                        break;

                    case 2:
                        PrintAllQuizzes(true);
                        break;

                    case 3:
                        RemoveQuiz();
                        break;

                    case 4:
                        ChangeQuizTitle();
                        break;
                    case 5:
                        PublishYourQuiz();
                        break;
                    case -1:
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                WaitUntilAnyKeyPress();
            }
        }

        private void PublishYourQuiz()
        {
            PrintAllQuizzes(true);

            try
            {
                int quizID = GetIntegerInputFromConsole("Select Quiz Id");

                var quiz = _quizService.GetQuizById(quizID);

                quiz.isPublished = true;

                _quizService.UpdatePublishStatus(quiz);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong, Please Try again");
                WaitUntilAnyKeyPress();
            }

        }

        public static bool IsUserAnswerCorrect(QuizQuestion question)
        {
            Console.WriteLine($"\n{question.Question}");
            List<string> answers = [.. question.WrongAnswers];

            int correctIndex = new Random().Next(0, answers.Count - 1);

            answers.Insert(correctIndex, question.CorrectAnswers[0]);

            Console.WriteLine("Options");
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine($"{i} - {answers[i]}");
            }

            bool isCorrectAnswer = correctIndex == GetIntegerInputFromConsole("Pick one");

            Console.WriteLine(isCorrectAnswer ? "Correct Answer" : "Wrong Answer");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            return isCorrectAnswer;
        }
        public void TakeQuiz()
        {
            PrintAllQuizzes(false);

            int quizId = GetIntegerInputFromConsole("Select a Quiz id");

            Quiz quiz = _quizService.GetQuizById(quizId);

            User user = LoggedInUser;

            int score = 0;

            List<QuizQuestion> correctlyAnswered = [];
            List<QuizQuestion> wrongAnswers = [];

            foreach (QuizQuestion question in quiz.QuizQuestions)
            {

                if (IsUserAnswerCorrect(question))
                {
                    correctlyAnswered.Add(question); score++;
                }
                else
                {
                    wrongAnswers.Add(question);
                }
            }

            Console.WriteLine($"Total Score ${score}");

            Console.WriteLine("Press any key to continue");

            Console.ReadKey();

            Console.Clear();

            QuizAttempt currentAttempt = new(quizId, user.Id, score, correctlyAnswered, wrongAnswers);

            _quizAttemptService.AddQuizAttempt(currentAttempt);
        }


        private void LastQuizReview()
        {
            var attempts = _quizAttemptService.GetAllQuizAttemptsForUser(LoggedInUser);

            if (attempts.Count == 0)
            {
                Console.WriteLine("No Quiz Taken");
            }
            else
            {
                Console.WriteLine(attempts.Last());

            }
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
                Console.WriteLine("4. Switch User Accounts");
                Console.WriteLine("-1. Quit");

                choice = GetIntegerInputFromConsole("Enter a Choice");
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        program.QuizManagement();
                        break;
                    case 2:
                        program.TakeQuiz();
                        break;
                    case 3:
                        program.LastQuizReview();
                        break;
                    case 4:
                        program.SwitchAccount();
                        break;
                    case -1:
                        break;


                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            }

        }

        private void SwitchAccount()
        {
            LoggedInUser = null;
            Login();
        }
    }
}
