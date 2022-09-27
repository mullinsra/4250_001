using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Isaiah Jayne
/// Philip Gaver
/// </summary>
namespace SE1ImpExercise
{
    /// <summary>
    /// /This is a program written to complete the exercise given in class in Software Engineering 1 by William Kinser on 9/27/2022
    /// The goal of this program is to use recursion to take the last number of a multiple digit number and and it to the rest of the digits
    /// The number used will be aqcuired via user input. The user shall input 2 non-zero, non-negative numbers whose sum is less than 4,294,967,295
    /// The program shall add these 2 numbers together and begin the process of cutting the last digit and adding it to the rest of the number recursively.
    /// </summary>
    class ClassEx
    {

        /// <summary>
        /// Adds the last digit of a number to the rest of the digits recursively until you are left with only a single digit
        /// </summary>
        /// <param name="x">This is the number gained via user input referred to earlier. It's the sum of 2 unsigned integers.</param>
        /// <returns>
        /// In the case the number is less than or equal to 0, simply return 0
        /// In the case that the number passed in is only 1 digit, you would simply return that digit.
        /// However, if that is not the case, You will need to take two substrings from the number.
        /// You'll seperate the final digit from the rest of the digits and then reconvert these substrings into ints and add them together.
        /// You then call the method again as it is recursive
        /// </returns>
        public static UInt32 addLastDigit(UInt32 x)
        {
            //ensure the number is above 1, if not return -
            if (x <= 0)
            {
                return 0;
            }
            else
            {
                //There is a better way to check for the length but I didn't think of it until after we wrote the design document

                string s = x.ToString();    //Convert to string
                if (s.Length.Equals(1))     //Check length, if 1 then reconvert to int and return
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
                    System.Environment.Exit(0);
                }

                //Instructions for second integer
                Console.WriteLine("Please input another non-zero, non-negative number. Note that the sum of these 2 numbers must be less than 4,294,967,295");
                string y = Console.ReadLine();
                //See if user wants to exit
                if (y.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    System.Environment.Exit(0);
                }

                //Loop to ensure that user input is valid with the specifications that are stated
                while (!UInt32.TryParse(x, out num1) || !UInt32.TryParse(y, out num2) || num1 <= 0 || num2 <= 0)
                {
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
                Console.WriteLine("" + addLastDigit(num1 + num2));

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
