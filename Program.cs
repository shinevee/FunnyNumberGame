// initalization
byte minrange = 1;
byte maxrange = 10;
byte fails = 0;
int points = 0;
bool correct = true;
byte number = 0;
byte guess;
byte easyMode;
byte maxFails;

// startup
Console.WriteLine("Welcome to the funny number game!");
Console.WriteLine("(Shinevee Edition)");

Console.WriteLine("");

Console.WriteLine("How many tries would you like to be able to make before Game Over?");
Console.WriteLine("*Must be a number between \"1\" and \"255\"");
Console.WriteLine("**If the answer is not a number between 1 and 255, it shall be inputted as \"4\"");
try
{
    maxFails = byte.Parse(Console.ReadLine());
}
catch (Exception)
{
    maxFails = 4;
}
if (maxFails == 0) {
    maxFails = 4;
}

Console.WriteLine("");

Console.WriteLine("Type \"1\" if you would like to regain a lost try for each correct guess");
try { easyMode = byte.Parse(Console.ReadLine()); } catch (Exception) { easyMode = 0; }


while (fails < maxFails)
{
    if (correct == true)
    {
        Console.WriteLine("Guess a number between " + minrange + " and " + maxrange);

        // random number generation
        Random rnd = new Random();

        Random rd = new Random();
        number = (byte)rd.Next(minrange, maxrange);
    //    Console.WriteLine("Debug line (it's " + number + ")"); // debug line, To Be Removed
    //    Console.WriteLine("Easymode is " + easyMode); // debug
        correct = false;
    }

    // static msg
    Console.Write("Guess: ");

    // game
    try { guess = byte.Parse(Console.ReadLine()); } catch (Exception) { guess = 0; }

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
        if (fails < (maxFails - 1))
        {
            Console.WriteLine(maxFails - fails + " mistakes until Game Over");
        }
        else if (fails == (maxFails - 1))
        {
            Console.WriteLine(maxFails - fails + " mistake until Game Over");
        }
        guess = 0;
    }
    else
    {
        Console.WriteLine("Correct");
        points++;
        if (easyMode == 1 && fails > 0)
            {       
                   Console.WriteLine("+1 possible mistakes");
                   fails--;
            }
        guess = 0;
        correct = true;
    }
}
while (fails == maxFails)
{
    Console.WriteLine("Game Over");
    Console.WriteLine("You guessed " + points + " numbers correctly");
    string here = (Console.ReadLine());
    fails++;
}