// initalization
byte minrange = 1;
byte maxrange;
byte fails = 0;
int points = 0;
bool correct = true;
byte number = 0;
byte guess;
byte easyMode = 0;
byte maxFails;
byte easyMode2 = 1;

Console.WriteLine("Welcome to the funny number game!");
Console.WriteLine("(Shinevee Edition)");


// setup
Console.WriteLine("\nWhat should the highest possible number generated be?");
Console.WriteLine("*Must be a number between \"2\" and \"255\"");
Console.WriteLine("**If the answer is not a number between 2 and 255, it shall be inputted as \"10\"");
try
{
    maxrange = byte.Parse(Console.ReadLine());
}
catch (Exception)
{
    maxrange = 10;
}
if (maxrange < 2)
{
    maxrange = 10;
}

Console.WriteLine("\nHow many tries would you like to be able to make before Game Over?");
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

if (maxFails > 1)
{
    Console.WriteLine("\nType \"1\" if you would like to regain a lost try for each correct guess");
    try { easyMode = byte.Parse(Console.ReadLine()); } catch (Exception) { easyMode = 0; }
    Console.WriteLine("");
    if (easyMode == 1)
    {
        Console.WriteLine("How many tries would you like to regain per each correct guess? (must be between 1 & 255)\n((it's too late to back out of this))");
        try { easyMode2 = byte.Parse(Console.ReadLine()); } catch (Exception) { easyMode2 = 1; }
        Console.WriteLine("");
        if (easyMode2 == 0)
        {
            easyMode2 = 1;
        }
    }
}

// game logic
while (fails < maxFails)
{
    if (correct == true)
    {
        Console.WriteLine("Guess a number between " + minrange + " and " + maxrange);

        // random number generation
        Random rnd = new Random();

        Random rd = new Random();
        number = (byte)rd.Next(minrange, maxrange);
     //   Console.WriteLine("Debug line (it's " + number + ")"); // debug line, To Be Removed
    //    Console.WriteLine("Easymode is " + easyMode); // debug
     //   Console.WriteLine("fails regained is " + easyMode2 + "\nand fail count is " + fails); //debug
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
            Console.WriteLine("\nIt's lower than " + guess);
        }
        else
        {
            Console.WriteLine("\nIt's higher than " + guess);
        }
        fails++;
        if (fails < (maxFails - 1))
        {
            Console.WriteLine(maxFails - fails + " mistakes until Game Over\n");
        }
        else if (fails == (maxFails - 1))
        {
            Console.WriteLine(maxFails - fails + " mistake until Game Over\n");
        }
        guess = 0;
    }
    else
    {
        Console.WriteLine("Correct");
        points++;
        if (easyMode == 1 && fails > 0)
            {       
                   
            int val = fails - easyMode2;
            if (val < 0)
            {
                val = 0;
            }
            Console.WriteLine("+" + easyMode2 + " possible mistakes\n(unless overflow would occur)\n((don't worry, you'll still regain tries))\n");
            fails = (byte)val;
            val = 0;
        }
        guess = 0;
        correct = true;
        Console.WriteLine("");
    }
}
while (fails == maxFails)
{
    Console.WriteLine("\nGame Over!");
    if (points != 1)
    {
        Console.WriteLine("You guessed " + points + " numbers correctly");
    }
    else {
        Console.WriteLine("You guessed " + points + " number correctly");
    }
    string here = (Console.ReadLine());
    fails++;
}