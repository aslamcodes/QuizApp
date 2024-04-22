namespace QuizBLLibrary
{

    public class UserNotFoundException : Exception
    {
        private readonly string msg;

        public UserNotFoundException()
        {
            msg = "User Not Found";
        }

        public override string Message => msg;
    }
}