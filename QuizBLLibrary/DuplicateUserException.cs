namespace QuizBLLibrary
{

    public class DuplicateUserException : Exception
    {
        private readonly string msg;

        public DuplicateUserException()
        {
            msg = "User Already exists";
        }

        public override string Message => msg;
    }
}