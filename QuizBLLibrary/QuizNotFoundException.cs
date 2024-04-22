namespace QuizBLLibrary
{

    public class QuizNotFoundException : Exception
    {
        private readonly string msg;

        public QuizNotFoundException()
        {
            msg = "Quiz Not Found";
        }

        public override string Message => msg;
    }
}