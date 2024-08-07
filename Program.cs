// initalization
byte minrange = 1;
byte maxrange = 10;
byte fails = 0;
int points = 0;
bool correct = true;
byte number = 0;
byte guess;
//bool easyMode = false;

// startup
Console.WriteLine("Welcome to the funny number game!");
Console.WriteLine("(Shinevee Edition)");

//Console.WriteLine("");

//Console.WriteLine("Type \"true\" for easy mode");
//try { easyMode = bool.Parse(Console.ReadLine()); } catch (Exception) { easyMode = false; }

while (fails < 4)
{
    if (correct == true)
    {
        Console.WriteLine("Guess a number between " + minrange + " and " + maxrange);

        // random number generation
        Random rnd = new Random();

        Random rd = new Random();
        number = (byte)rd.Next(minrange, maxrange);
   Console.WriteLine("Debug line (it's " + number + ")"); // debug line, To Be Removed
//        Console.WriteLine("Easymode is " + easyMode); // debug
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
        if (fails < 3)
        {
            Console.WriteLine(4 - fails + " mistakes until Game Over");
        }
        else
        {
            Console.WriteLine(4 - fails + " mistake until Game Over");
        }
        guess = 0;
    }
    else
    {
        Console.WriteLine("Correct");
        points++;
        //    if (easyMode = true && fails > 0)
        //    {       
        //           Console.WriteLine("+1 possible mistakes");
        //           fails--;
        //     }
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