// Adelaide Damrau, Hannah Taylor, Janine Day
// CSCI 4250 - Implementation Exercise
// 9/27/2022

using System.Text.RegularExpressions;

// Purpose: Using Recursion; take two numbers in from the user (a human) and add them together then separate the
// least significant digit and add it the remaining digits and so on until you have a single digit answer. 
public class DigitRecursion
{
    // Prompts for users input, validates with Validate method, and completes purpose using recursion method
    static void Main()
    {
        string firstInput = "", secondInput = "";
        bool valid = false;

        // Prompt for input until valid
        do
        {
            Console.WriteLine("Please enter an integer within 0 - 10000 (with no commas): ");
            firstInput = Console.ReadLine();

            valid = Validate(firstInput);
        }
        while (valid == false);

        valid = false;
        // Prompt for input until valid
        do
        {
            Console.WriteLine("Please enter another integer within 0 - 10000 (with no commas): ");
            secondInput = Console.ReadLine();

            valid = Validate(secondInput);
        }
        while (valid == false);

        // convert string to uint
        uint first = UInt32.Parse(firstInput);
        uint second = UInt32.Parse(secondInput);

        uint result = Recursion(first + second);

        Console.WriteLine(result);
    }

    // Ensure user input is a positive unsigned integer following prompt guidelines
    // Put guidelines to prevent stackoverflow errors and to follow uint standards
    public static bool Validate(string input)
    {
        // ensures there was an input
        if (input == null || input == "")
            return false;

        // ensures digits only
        if (!Regex.IsMatch(input, @"^\d*$"))
            return false;
        
        // ensures input is in range
        if (UInt32.Parse(input) > 10000 || UInt32.Parse(input) < 0)
            return false;

        return true;
    }

    // Takes the least significant digit and sums it with the remaining value
    // Recurse until single digit answer is found
    // Returns single digit answer
    public static uint Recursion(uint sum)
    {
        // mod will return the least sig digit - the remainder
        uint lsd = sum % 10;

        // div will remove the least sig digit
        uint remaining = sum / 10;


        uint newSum = lsd + remaining;

        // not single digit, continue with recursion
        if (newSum > 9)
            newSum = Recursion(newSum);
        
        return newSum;
    }

}