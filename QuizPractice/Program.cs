namespace QuizPractice;

class Program
{
    private static Dictionary<string, string> _qa  = new Dictionary<string, string>
    {
        {"What is 1+1?", "2"},
        {"What is my name?", "Lucas Bubner"},
        {"Where is Earth?", "Solar system"},
        {"Can you eat a cactus?", "yes"}
    };

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to one of the quizzes of all time!");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();
        Console.Clear();
        int correctQuestions = 0;
        foreach (KeyValuePair<string, string> entry in _qa)
        {
            Console.WriteLine(entry.Key);

            string? userInput;
            for (;;)
            {
                userInput = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInput))
                {
                    break;
                }
                Console.WriteLine("Invalid!");
            }

            if (userInput.ToLower() == entry.Value.ToLower())
            {
                Console.WriteLine("Correct!");
                correctQuestions++;
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }
        Console.WriteLine($"You got {correctQuestions}/{_qa.Count} questions right!");
        if (correctQuestions == _qa.Count)
        {
            Console.WriteLine("You are a genius!");
        }

        Console.ReadKey();
    }
}