WCK- The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. 

Hard to read the design pics but I could make out that you considered various test cases including edge cases and exceptions. You had some 
psuedo code to layout the design. You restated the problem (understanding requirements).
    
Overall, very good!! You avoided some of the pitfalls others fell into. Some room for improvement but that's what is really fun about programming. 
    
    COmments inlined below prefixed with WCK-
    

// Adelaide Damrau, Hannah Taylor, Janine Day
// CSCI 4250 - Implementation Exercise
// 9/27/2022

using System.Text.RegularExpressions;

// Purpose: Using Recursion; take two numbers in from the user (a human) and add them together then separate the
// least significant digit and add it the remaining digits and so on until you have a single digit answer. 
public class DigitRecursionm                   WCK- is it normal practice in C# that class names AND methods are capatilized? 
{
    // Prompts for users input, validates with Validate method, and completes purpose using recursion method
    static void Main()
    {
        string firstInput = "", secondInput = "";              WCK- this is the last file I looked at. Everyone else did num1, num2. I like this better.
        bool valid = false;                                     WCK- good job initializing your variables.

        // Prompt for input until valid
        do                                      WCK- do-while is a good choice 
        {
            Console.WriteLine("Please enter an integer within 0 - 10000 (with no commas): ");       WCK- so you constrained the problem. Cool. This may have 
                                                                                                          been in the design pics that I couldn't read. 
                                                                                                          This avoids overflow/underflow etc. (if user does it)
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
        uint first = UInt32.Parse(firstInput);             WCK- help me with C#. is uint the same as UInt32?
        uint second = UInt32.Parse(secondInput);

        uint result = Recursion(first + second);

        Console.WriteLine(result);
    }

    // Ensure user input is a positive unsigned integer following prompt guidelines
    // Put guidelines to prevent stackoverflow errors and to follow uint standards
    public static bool Validate(string input)
    {
        // ensures there was an input
        if (input == null || input == "")            WCK- NICE. Probably will never happen but now the code is more robust.
            return false;

        // ensures digits only
        if (!Regex.IsMatch(input, @"^\d*$"))          WCK- I have to use a reference book when doing regex so I'll take your word for it
            return false;
        
        // ensures input is in range
        if (UInt32.Parse(input) > 10000 || UInt32.Parse(input) < 0)
            WCK- you use 10000 here as a literal constant, and you have it in the prompt in the method that calls here. from a maintainability point, what
            if we raise the upper limit; we have to find everyplace to change it. You could declare a static constant attribute of the class and use it 
                instead of a literal constant and a string; which means you only maintain it in one place.
            It is more readable when you do compound condition statements if you use parens and carriage returns. Also, rather than parsing the same string
                string twice, do it once. It's more efficient. DOesn't matter here but if you were in a very large loop, it adds up.
                e.g.    UInt32 parsedValue = UInt32.Pars(input);
                        If ((parsedValue > maxValue) ||
                             (parsedValue < minValue))
                            This reads better and is more maintainable, and is more efficient.
            return false;

        return true;
    }

    // Takes the least significant digit and sums it with the remaining value               WCK- good comments
    // Recurse until single digit answer is found
    // Returns single digit answer
    public static uint Recursion(uint sum)
    {
        // mod will return the least sig digit - the remainder
        uint lsd = sum % 10;

        // div will remove the least sig digit
        uint remaining = sum / 10;
WCK- the above is the correct way to do this.

        uint newSum = lsd + remaining;

        // not single digit, continue with recursion
        if (newSum > 9)
            newSum = Recursion(newSum);
        
        return newSum;
    }

}
