using System;

class Program
{
    static void Main(string[] args)
    {
        Problems problems = new Problems();
        Console.WriteLine("Hi, select an option: \n" +
            "1) Compound Interest.\n" +
            "2) Grading System.\n" +
            "3) Rock Paper Scissors.\n" +
            "4) Guess the Number.\n" +
            "0) Exit.");
        int option = Convert.ToInt32(Console.ReadLine());

        while (option != 0)
        {
            switch (option)
            {
                case 1:
                    problems.CompoundInterest();
                    break;
                case 2:
                    problems.GradingSystem();
                    break;
                case 3:
                    problems.RockPaperScissors();
                    break;
                case 4:
                    problems.GuessTheNumber();
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
            Console.WriteLine("Select another option or 0 to exit: ");
            option = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Thanks for using our software!");
    }
}

class Problems
{
    public void CompoundInterest()
    {
        const int annualInterest = 5, years = 10;
        const decimal startCapital = 1000;
        decimal interest = startCapital * (decimal)Math.Pow(1 + (annualInterest / 100.0), years);

        Console.WriteLine(
            $"The starter capital was {startCapital}, the capital after {years} years is: {interest}");
    }

    public void GradingSystem()
    {
        Console.WriteLine("Enter the student's average (0-100): ");
        int average = Convert.ToInt32(Console.ReadLine());

        if (average >= 90 && average <= 100)
            Console.WriteLine("Final Grade: Pass with distinction");
        else if (average >= 80 && average < 90)
            Console.WriteLine("Final Grade: Pass with honors");
        else if (average >= 70 && average < 80)
            Console.WriteLine("Final Grade: Approved");
        else if (average >= 0 && average < 70)
            Console.WriteLine("Final Grade: Reproved");
        else
            Console.WriteLine("Invalid average. Please enter a value between 0 and 100.");
    }

    public void RockPaperScissors()
    {
        bool gameLoop = true;
        int userPoints = 0, computerPoints = 0;
        Random randomChoice = new Random();

        while (gameLoop)
        {
            Console.WriteLine("Rock Paper Scissors Game, select an option: \n" +
                "1. Rock\n2. Paper\n3. Scissors");
            string userChoice = Console.ReadLine();
            int computerChoice = randomChoice.Next(1, 4);

            Console.WriteLine($"Computer chose {GetChoiceName(computerChoice)}");

            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("User chose Rock");
                    ProcessGameResult(computerChoice, 1, ref userPoints, ref computerPoints);
                    break;
                case "2":
                    Console.WriteLine("User chose Paper");
                    ProcessGameResult(computerChoice, 2, ref userPoints, ref computerPoints);
                    break;
                case "3":
                    Console.WriteLine("User chose Scissors");
                    ProcessGameResult(computerChoice, 3, ref userPoints, ref computerPoints);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    continue;
            }

            Console.WriteLine($"User points: {userPoints} - Computer points: {computerPoints}");
            Console.WriteLine("Do you wish to play again? (Y/N)");
            string playAgain = Console.ReadLine().ToLower();
            if (playAgain != "y")
                gameLoop = false;
        }
    }

    public void GuessTheNumber()
    {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        int userGuess = 0;

        Console.WriteLine("The computer has generated a number between 1 and 100. Try to guess it!");

        while (userGuess != numberToGuess)
        {
            Console.WriteLine("Enter your guess: ");
            userGuess = Convert.ToInt32(Console.ReadLine());

            if (userGuess > numberToGuess)
            {
                Console.WriteLine("Too high, try again.");
            }
            else if (userGuess < numberToGuess)
            {
                Console.WriteLine("Too low, try again.");
            }
            else
            {
                Console.WriteLine($"Correct! The number was {numberToGuess}.");
            }
        }
    }

    private void ProcessGameResult(int computerChoice, int userChoice, ref int userPoints, ref int computerPoints)
    {
        if (userChoice == computerChoice)
        {
            Console.WriteLine("It's a tie.");
        }
        else if ((userChoice == 1 && computerChoice == 3) ||
                 (userChoice == 2 && computerChoice == 1) ||
                 (userChoice == 3 && computerChoice == 2))
        {
            Console.WriteLine("User wins!");
            userPoints++;
        }
        else
        {
            Console.WriteLine("Computer wins!");
            computerPoints++;
        }
    }

    private string GetChoiceName(int choice)
    {
        return choice switch
        {
            1 => "Rock",
            2 => "Paper",
            3 => "Scissors",
            _ => "Unknown"
        };
    }
}
