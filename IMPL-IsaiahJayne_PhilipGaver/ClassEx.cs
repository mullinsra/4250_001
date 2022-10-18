WCK -  The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc.
    You do most of these 

Notes on your design;
- your overview and goal and requirements don't mention adding the least significant digit to the remaining digits after being removed. 
    It only mentions subtracting the digits
- your overview and goal and requirements don't mention a constraint you add later in the design of the sum being less than some number 
    (what is the significance of this number?).
    
 Comments in the code prefixed with WCK-. look for these.
     Your code counts on the user following instructions. Not realistic.
 Did did the long way using strings. That's okay since you restricted it to unsigned ints. 
     I think you have unnecessary code here and duplication of user inputs is less maintainable than it could be.
 Really good comments throughout. 
    
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Isaiah Jayne
/// Philip Gaver
/// </summary>
namespace SE1ImpExercise          WCK- curious as to why you abbreviate Imp? typing the whole thing makes it clear and doesn't cost performance or memory
{
    /// <summary>               WCK- this is good. Of course, I didn't say non-zero or indicate integers but that's okay; you can constrain it for now.
    /// /This is a program written to complete the exercise given in class in Software Engineering 1 by William Kinser on 9/27/2022
    /// The goal of this program is to use recursion to take the last number of a multiple digit number and and it to the rest of the digits
    /// The number used will be aqcuired via user input. The user shall input 2 non-zero, non-negative numbers whose sum is less than 4,294,967,295
    /// The program shall add these 2 numbers together and begin the process of cutting the last digit and adding it to the rest of the number recursively.
    /// </summary>
    class ClassEx             WCK- again with abbreviation. what does Ex mean?
        
    {

        /// <summary>
        /// Adds the last digit of a number to the rest of the digits recursively until you are left with only a single digit
        /// </summary>
        /// <param name="x">This is the number gained via user input referred to earlier. It's the sum of 2 unsigned integers.</param>
        /// <returns>                            
                                  WCK- it is only the user input value the first time it is called. but it's called recursively. 
        
        /// In the case the number is less than or equal to 0, simply return 0
        /// In the case that the number passed in is only 1 digit, you would simply return that digit.        WCK- same as statement above, why test for 0
        /// However, if that is not the case, You will need to take two substrings from the number.
        /// You'll seperate the final digit from the rest of the digits and then reconvert these substrings into ints and add them together.
                                      WCK- seperate is not a word
        /// You then call the method again as it is recursive
        /// </returns>
        public static UInt32 addLastDigit(UInt32 x)
        {
            //ensure the number is above 1, if not return -          WCK- can an UInt32 be less than zero? is this if statement needed?
            if (x <= 0)
            {
                return 0;
            }
            else
            {
                //There is a better way to check for the length but I didn't think of it until after we wrote the design document
                
                WCK- there's a better way to do the whole thing using Modulo - conversion to and from string is processor expensive

                string s = x.ToString();    //Convert to string
                if (s.Length.Equals(1))     //Check length, if 1 then reconvert to int and return         WCK- wouldn't zero pass this test too?
                {
                    return UInt32.Parse(s);
                }
                else
                {                           //Seperate final digit from the rest of the digits using substrings, convert both strings back into UInt32's and add
                    string z = s.Substring(0, s.Length - 1);
                    string q = s.Substring(s.Length - 1, 1);
                    UInt32 final = UInt32.Parse(z) + UInt32.Parse(q);
                    return addLastDigit(final);                         //As this is recursive you recall the method with the goal of reducing the number to a single digit
                }
            }
        }

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            bool run = true;                        //Boolean the decides whether the program will run or not. Changed at the end of the program when the user is asked if they'd like to run the program again.
            while (run)
            {
                
                WCK - good. you comment these and initialize them. Could the naming be more meaningful?
                //These will hold the 2 integers the user will input.
                UInt32 num1 = 0;
                UInt32 num2 = 0;

                //Inform user they may exit
                Console.WriteLine("If you would like to exit at any point, just type exit unless otherwise specified.");

                //Instructions for first integer
                Console.WriteLine("Please Input a non-zero, non-negative number.");
                string x = Console.ReadLine();
                //See if user wants to exit
                if (x.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    System.Environment.Exit(0);          WCK- Yuck. Multiple Exit points!!! why not set run to false and use an elseif
                }

                //Instructions for second integer
                Console.WriteLine("Please input another non-zero, non-negative number. Note that the sum of these 2 numbers must be less than 4,294,967,295");
                
                WCK- as a user of a program, "must be less than 4,294,967,295" would tick me off. Like I'm going to do the math. That's what computers are for.
                
                string y = Console.ReadLine();
                //See if user wants to exit
                if (y.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    System.Environment.Exit(0);
                }

                //Loop to ensure that user input is valid with the specifications that are stated
                while (!UInt32.TryParse(x, out num1) || !UInt32.TryParse(y, out num2) || num1 <= 0 || num2 <= 0)
                    WCK - when doing a compound conditional statement, use parens and carriage returns to make it easier to read and maintain..
                    e.g.,     (!UInt32.TryParse(x, out num1) ||    // make sure first number is an unsigned integer
                                !UInt32.TryPars(y, out num2) ||    // make sure second number is an unsigned integer
                                (num1 <= 0) ||                     // make sure first number isn't negative (????? isn't this redudant with the first check????)
                                (num2 <= 0) )                      // ditto
                {
                    WCK- rather than copying and pasting the code, why wouldn't you use a do-while loop. Does C# have that?
                        now you have to maintain the prompting and validation in two places and YUCK more exit points!!!!
                        
                        
                    //Inform user they were incorrect
                    Console.WriteLine("\nYou did not read the instructions, try again.");

                    Console.WriteLine("Please Input a non-zero, non-negative number");
                    x = Console.ReadLine();
                    if (x.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        System.Environment.Exit(0);
                    }

                    Console.WriteLine("Please input another non-zero, non-negative number. Note that the sum of these 2 numbers must be less than 4,294,967,295");
                    y = Console.ReadLine();
                    if (y.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        System.Environment.Exit(0);
                    }
                }

                //Add the 2 digits and pass them to the recursive method. Print the output
                Console.WriteLine("" + addLastDigit(num1 + num2));      WCK- I guess you are trusting the user to not enter too large a number for either/both inputs

                //Ask user if they'd like to run the program again, they may answer 'yes or no'. The response is case insensitive
                Console.WriteLine("Would you like to run the program again? Enter yes or no");
                x = Console.ReadLine();

                //Make sure that the user entered yes or no
                while (!x.Equals("yes", StringComparison.OrdinalIgnoreCase) && !x.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid input, please type yes or no");
                    x = Console.ReadLine();
                }

                //If the user entered no, change run to false so the program will exit
                if(x.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    run = false;
                }
            }
        }
    }
}
