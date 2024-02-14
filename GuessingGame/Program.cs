namespace GuessingGame;

class Program
{
    private static Random _rng = new();
    private const int MaxGuesses = 5;
    public static void Main(string[] args)
    {
        for (;;)
        {
            int chosenNumber = _rng.Next(1, 100);
            int guessCounts = 0;
            int lastGuess = 0;
            while (guessCounts < MaxGuesses)
            {
                Console.WriteLine($"Guess my number 1-100! {MaxGuesses - guessCounts} chances left.");
                lastGuess = GetUserInt();
                if (lastGuess == chosenNumber)
                {
                    Console.WriteLine("You win!");
                    break;
                }

                if (lastGuess > chosenNumber)
                {
                    Console.WriteLine("Too high");
                }
                else if (lastGuess < chosenNumber)
                {
                    Console.WriteLine("Too low");
                }

                guessCounts++;
            }
            Console.WriteLine($"It took you {guessCounts} guesses,");
            Console.WriteLine(lastGuess == chosenNumber ? "and you won!" : $"and you still lost!! The number was {chosenNumber}");
            Console.WriteLine("Play again? (y)");
            if (Console.ReadLine().ToLower() != "y")
                break;
        }
    }

    private static int GetUserInt()
    {
        int userInput;
        for (;;)
        {
            try
            {
                userInput = int.Parse(Console.ReadLine());
                break;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid! No number!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid! Not a number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid! Number far too large!");
            }
        }

        return userInput;
    }
}
