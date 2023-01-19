using System;


enum MessageVerbosity
{
    None,
    Limited,
    Verbose
}

class P1
{

    static Random randomRoller = new Random();

    static int TestCount = 5;


    public static JumpPrime getNewJumper()
    {
        uint initValue = 1000 + (uint)(randomRoller.Next() % 9000);
        JumpPrime returnJumper = new JumpPrime(initValue);
        return returnJumper;
    }

    public static void RandomJumpTest(MessageVerbosity verbosity = MessageVerbosity.Verbose)
    {


        JumpPrime newJumper = getNewJumper();
        uint currentValue;
        int totalQueryCounter = 0;
        int jumpCounter = 0;

        if (verbosity == MessageVerbosity.Verbose)
        {
            Console.WriteLine("Testing new JumpPrime object, verbose reporting:");
            Console.WriteLine("Initial JumpPrime value: " + newJumper.GetCurrentValue());

        }
        else if ((verbosity == MessageVerbosity.Limited))
        {
            Console.WriteLine("Testing new JumpPrime object, limited reporting:");
            Console.WriteLine("Initial JumpPrime value: " + newJumper.GetCurrentValue());
        }

        while (newJumper.IsActive())
        {
            currentValue = newJumper.GetCurrentValue();
            if (verbosity == MessageVerbosity.Verbose)
            {
                Console.WriteLine("Current object value: " + currentValue);
            }

            int queryCounter = 0;

            while (newJumper.GetCurrentValue() == currentValue)
            {
                if (queryCounter % 2 == 0)
                {
                    newJumper.up();
                }
                else
                {
                    newJumper.down();
                }
                queryCounter++;
                totalQueryCounter++;
            }

            jumpCounter++;

            if (verbosity == MessageVerbosity.Verbose)
            {
                Console.WriteLine("Queries until jump: " + queryCounter);
            }
        }

        if (verbosity != MessageVerbosity.None)
        {
            Console.WriteLine("Final JumpPrime value: " + newJumper.GetCurrentValue());
            Console.WriteLine("Total number of jumps: " + jumpCounter);
            Console.WriteLine("Queries until object deactivated: " + totalQueryCounter);
        }

    }

    public static void MultipleJumpTest(MessageVerbosity verbosity = MessageVerbosity.Verbose)
    {

        if (verbosity != MessageVerbosity.None)
        {
            Console.WriteLine("Testing " + TestCount + " random JumpPrime objects\n");
        }
        for (int i = 0; i < TestCount; i++)
        {
            RandomJumpTest(MessageVerbosity.Limited);
            Console.WriteLine();
        }
    }

    public static void WriteSpacer()
    {
        Console.WriteLine("\n" +
            "* * * * * * * * * * * * * * * * * *" +
            "\n");
    }


    public static void Main(string[] args)
    {

        RandomJumpTest(MessageVerbosity.Verbose);

        WriteSpacer();

        MultipleJumpTest();





    }
}
