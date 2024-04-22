namespace QuizBLLibrary
{

    public class DuplicateQuizException : Exception
    {
        private readonly string msg;

        public DuplicateQuizException()
        {
            msg = "Quiz Already exists";
        }

        public override string Message => msg;

    }
}