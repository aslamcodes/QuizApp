namespace QuizApp
{
    public class MenuUI
    {
        private readonly Dictionary<int, (string, Action)> Functions;

        public MenuUI(List<(string, Action)> functions)
        {
            this.Functions = [];
            for (int i = 0; i < functions.Count; i++)
            {
                this.Functions[i] = functions[i];
            }
        }

        public MenuUI(List<string> initStrings, List<(string, Action)> functions) : this(functions)
        {

            foreach (var text in initStrings)
            {
                Console.WriteLine(text);
            }

        }


        public Action this[int index]
        {
            get
            {
                return Functions[index].Item2;
            }
        }

        public void Start()
        {
            int? choice = 0;

            if (Functions.Count == 0)
            {
                Console.WriteLine("No functions configured");
                return;
            }

            while (choice != -1)
            {
                foreach (KeyValuePair<int, (string, Action)> entry in Functions)
                {
                    Console.WriteLine($"{entry.Key} - {entry.Value.Item1}");
                }

                Console.WriteLine("Enter a choice");
                choice = null;

                while (choice == null)
                {
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input, please try again");
                    }
                }



                if (choice > Functions.Keys.Max())
                {
                    Console.WriteLine("Invalid Choice");
                }
                else if (choice < 0)
                {
                    break;
                }
                else
                {
                    Functions[(int)choice].Item2();
                }

                Console.WriteLine("Press a key to continue");
                Console.ReadKey();
                Console.Clear();
            }



        }
    }
}
