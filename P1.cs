// Andrew Asplund
// CPSC 5011
// Assignment P1
// January 19, 2022

// see license.md for copyright/license information

using System;


/// <summary>
/// MessageVerbosity tracks different levels of message and reporting
/// verbosity used in the tests of this application.
/// </summary>
enum MessageVerbosity
{
    None,
    Limited,
    Verbose
}

class P1
{

    // psuedo-random number generator for generating initial values.
    static Random randomRoller = new Random();

    static int TestCount = 5;

    static uint TestValue = 2488;
    static uint TestUpPrime = 2503;
    static uint TestDownPrime = 2477;


    /// <summary>
    /// GetNewJumper creates a new <c>JumpPrime</c> object with an initial
    /// value randomly generated between 1000 and 9999 (inclusive).
    /// </summary>
    /// <returns>A <c>JumpPrime</c> object with a randomly determined
    /// initial value.</returns>
    public static JumpPrime GetNewJumper()
    {
        uint initValue = 1000 + (uint)(randomRoller.Next() % 9000);
        JumpPrime returnJumper = new JumpPrime(initValue);
        return returnJumper;
    }

    /// <summary>
    /// FixedJumpTest tests whether the <c>JumpPrime</c> class functions correctly with the
    /// test case provided in the assignment definition.
    /// </summary>
    public static void FixedJumpTest()
    {
        JumpPrime newJumper = new JumpPrime(TestValue);

        Console.WriteLine("New JumpPrime object instanced with initial value of " + TestValue + ".");
        Console.WriteLine("Testing up method, expecting value " + TestUpPrime + ", received: " + newJumper.up());
        Console.WriteLine("Testing down method, expecting value " + TestDownPrime + ", received: " + newJumper.down());
    }

    /// <summary>
    /// RandomJumpTest performs a series of queries on a <c>JumpPrime</c> object, tracking
    /// the numer of queries until the object jumps to a new value, the number of jumps
    /// taken by the object, and the total number of queries until the object deactivates.
    /// </summary>
    /// <param name="verbosity">controls the number of messages transmitted to the console
    /// by the RandomJumpTest method.</param>
    public static void RandomJumpTest(MessageVerbosity verbosity = MessageVerbosity.Verbose)
    {


        JumpPrime newJumper = GetNewJumper();

        // set test recording values
        uint currentValue;
        int totalQueryCounter = 0;
        int jumpCounter = 0;

        // print verbose verbosity message
        if (verbosity == MessageVerbosity.Verbose)
        {
            Console.WriteLine("Testing new JumpPrime object, verbose reporting:");
            Console.WriteLine("Initial JumpPrime value: " + newJumper.GetCurrentValue());

        }
        // print limited verbosity message
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

    /// <summary>
    /// Performs multiple Jump Tests in succession.
    /// </summary>
    /// <param name="verbosity">controls the number of messages transmitted to the console
    /// by the MultipleJumpTest method.</param>
    public static void MultipleJumpTest(MessageVerbosity testVerbosity = MessageVerbosity.Verbose)
    {
        MessageVerbosity unitVerbosity;
        // sets the individual test verbosities to limited unless the main verbosity is
        // already set to none.
        if (testVerbosity == MessageVerbosity.None)
        {
            unitVerbosity = MessageVerbosity.None;
        }
        else
        {
            unitVerbosity = MessageVerbosity.Limited;
        }


        if (testVerbosity != MessageVerbosity.None)
        {
            Console.WriteLine("Testing " + TestCount + " random JumpPrime objects\n");
        }

        for (int i = 0; i < TestCount; i++)
        {

            RandomJumpTest(unitVerbosity);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// ReviveTest tests whether the Revive method of the <c>JumpPrime</c> class properly
    /// revives an inactive object.
    /// </summary>
    /// <param name="verbosity">controls the number of messages transmitted to the console
    /// by the ReviveTest method.</param>
    public static void ReviveTest(MessageVerbosity verbosity = MessageVerbosity.Verbose)
    {
        JumpPrime newJumper = GetNewJumper();
        int queryCounter = 0;

        if (verbosity == MessageVerbosity.Verbose)
        {
            Console.WriteLine("Conducting JumpPrime Revive Test, verbose reporting:");
            Console.WriteLine("Initial JumpPrime value: " + newJumper.GetCurrentValue());

        }
        // print limited verbosity message
        else if ((verbosity == MessageVerbosity.Limited))
        {
            Console.WriteLine("Conducting JumpPrime Revive Test, limited reporting:");
            Console.WriteLine("Initial JumpPrime value: " + newJumper.GetCurrentValue());
        }

        while (newJumper.IsActive())
        {
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
            }
        }
        if (verbosity == MessageVerbosity.Verbose)
        {
            Console.WriteLine("JumpPrime object is decativated: " + !newJumper.IsActive());
            Console.WriteLine("JumpPrime object decativated after " + queryCounter + " queries.");
        }

        if (verbosity != MessageVerbosity.None)
        {
            Console.WriteLine("Reviving JumpPrime Object");
        }

        newJumper.Revive();

        if (verbosity != MessageVerbosity.None)
        {
            Console.WriteLine("JumpPrime object is active: " + newJumper.IsActive());
        }

        if (verbosity == MessageVerbosity.Verbose)
        {
            Console.WriteLine("JumpPrime object stopped on value: " + newJumper.GetCurrentValue());
        }

    }

    /// <summary>
    /// ReviveFailure tests whether or not the <c>JumpPrime</c> object properly disables itself
    /// when an attempt to Revive the object is done while the object is active.
    /// </summary>
    /// <param name="verbosity">controls the number of messages transmitted to the console
    /// by the ReviveTest method.</param>
    public static void ReviveFailure(MessageVerbosity verbosity = MessageVerbosity.Verbose)
    {
        JumpPrime newJumper = GetNewJumper();

        if (verbosity == MessageVerbosity.Verbose)
        {
            Console.WriteLine("Conducting JumpPrime Revive Failure Test, verbose reporting:");

        }
        // print limited verbosity message
        else if (verbosity == MessageVerbosity.Limited)
        {
            Console.WriteLine("Conducting JumpPrime Revive Failure Test, limited reporting:");
        }

        if (verbosity != MessageVerbosity.None)
        {
            Console.WriteLine("JumpPrime object is active: " + newJumper.IsActive());
            Console.WriteLine("Attempting to Revive JumpPrime object.");
        }

        newJumper.Revive();

        if (verbosity != MessageVerbosity.None)
        {
            Console.WriteLine("JumpPrime object is active: " + newJumper.IsActive());
        }
        if (verbosity == MessageVerbosity.Verbose)
        {
            Console.WriteLine("JumpPrime object is permanently deactivated: " + newJumper.IsDeactivated());
        }



    }

    /// <summary>
    /// WriteSpacer prints a divider in the console output preceded and followed
    /// by newlines. Used for formatting.
    /// </summary>
    public static void WriteSpacer()
    {
        Console.WriteLine("\n" +
            "* * * * * * * * * * * * * * * * * *" +
            "\n");
    }


    public static void Main(string[] args)
    {


        FixedJumpTest();

        WriteSpacer();

        RandomJumpTest(MessageVerbosity.Verbose);

        WriteSpacer();

        MultipleJumpTest();

        WriteSpacer();

        ReviveTest();

        WriteSpacer();

        ReviveFailure();



    }
}
