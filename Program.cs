// initalization
int minrange = 1;
int maxrange = 10;
int fails = 0;
int points = 0;
bool correct = true;
int number = 0;

// startup
Console.WriteLine("Welcome to the funny number game!");
Console.WriteLine("(Shinevee Edition)");

while (fails < 4)
{
    if (correct == true)
    {
        Console.WriteLine("Guess a number between " + minrange + " and " + maxrange);

        // random number generation
        Random rnd = new Random();

        Random rd = new Random();
        number = rd.Next(minrange, maxrange);
    //    Console.WriteLine("Debug line (it's " + number + ")"); // debug line, To Be Removed
        correct = false;
    }

    // static msg
    Console.Write("Guess: ");

    // game
    int guess = Convert.ToInt32(Console.ReadLine());
    if (guess != number)
    {
        if (guess > number)
        {
            Console.WriteLine("It's lower than " + guess);
        }
        else
        {
            Console.WriteLine("It's higher than " + guess);
        }
        fails++;
        if (fails < 4)
        {
            Console.WriteLine(4 - fails + " mistakes until Game Over");
        }
        guess = 0;
    }
    else
    {
        Console.WriteLine("Correct");
        points++;
        guess = 0;
        correct = true;
    }
}
while (fails == 4)
{
    Console.WriteLine("Game Over");
    Console.WriteLine("You guessed " + points + " numbers correctly");
    string here = (Console.ReadLine());
    fails++;
}