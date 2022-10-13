WCK - Overall, very good job. The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. You did some of this. Maybe you ran out of time before you got to test cases and test data.

WCK - comments below with WCK- 
	

/***
 * 

Implementation for the project

Cory Windham
Ty Seiber
Ethan Morgan

Recursion

Definition of Done - break out of the loop and print one number. (exceptions for max int, not int, and null)    WCK- the code excludes negatives too.

Flow
	-set variable boolean 
		-start(false)

--Main
	-While(start is false)
		-try/catch for null, or for not int
			-Ask the user for two separate numbers
				-store in variables
					-num1 store
					-num2 store
				--use int check booleans to check and see if the variable is an int and not null
					-set to true
			-if num1 and num2 are not null, >0, and int
				-start == true
			-else 
				-throw exception message stay in loop
	-perform addition
		-result int store

--Recursion
	-separate least significant digit
		-cast result to a string
	-if statement to check if number is 1 digit //if string.length > 1 then run recursion
		-call length-1 to grab least significant digit
		-store new string
			-fronthalf string
			-asshalf string
		-cast both back to int 
		-add least with most
	-at the end print result

 * 
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_Red_Pandas
{
    internal class Program
    {
        //building not for max int currently once we get it working will go back in and add 
        static void Main(string[] args)
        {
            bool start = false;                                                                         //used for while loop
            bool keepGoing = true;                                                                      //used to see if the user wants to exit or continue with new numbers 
            bool finish = true;                                                                         //used for user validation at the exit stage
            bool intCheck1 = false;                                                                     //bools to check if nums are actualy ints
            bool intCheck2 = false;                                                                     //bools to check if nums are actualy ints
            int num1 = 0;
            int num2 = 0;
            var num1_check = " n";                                                                      //initial variables taken in to check
            var num2_check = " n";                                                                      //initial variables taken in to check
            int max = int.MaxValue;                                                                     //check for max number
            int userNum = 0;                WCK- good job; meaningful names (mostly) and comments and initialized!!


            line();
            //start program
            Console.WriteLine("This program will take two positive numbers as input, and recursively\n" +
                "separarte off the least significant digit and add it back to the \nprevious numbers,  " +
                "if the result is 1 digit it will be returned and printed.");
            line();
            while(keepGoing)
            {
                //if user wants to add more than one set of numbers then reset the inital while loop values           WCK- NICE!
                start = false;
                finish = true;

                while (start == false)
                {
                    //num1 
                    Console.WriteLine("\nEnter the first number: ");

                    //int check
                    num1_check = Console.ReadLine();
                    intCheck1 = int.TryParse(num1_check, out num1);

                    //num2
                    Console.WriteLine("Enter the second number: ");

                    //int check
                    num2_check = Console.ReadLine();
                    intCheck2 = int.TryParse(num2_check, out num2);


                    //condition to get out of while loop
                    if (intCheck1 && intCheck2 && num1 < max && num2 < max && num1 >= 0 && num2 >= 0)
			     WCK- when you do multiple compounded conditions use Parens to group them so it is easier to read
				   e.g.   (intCheck1 && intCheck2 && (num1 < max) && (num2 < max) && (num1 >= 0) && (num2 >= 0) )

                        start = true;
                    //exception
                    else
                        line();
                        Console.WriteLine("\nOops looks like something was wrong remember to input a positive number " +
                            "\n(hint: letters are not numbers)\n");
                    line(); 

                }

                //after loop add nums
                int result = num1 + num2;                    WCK- what if num1 and num2 are both equal to (MaxInt - 5) ???

                IntRecusion(result);

                while (finish)
                {

                    //Asking the user for input on whether or not they would like to continue or exit, then validating the input.
                    Console.WriteLine("Would you like to go again? To insert a new set of numbers insert '1' or '0' to exit.");
                    var userInput = Console.ReadLine();
                    bool userCheck = int.TryParse(userInput, out userNum);

                    //Breaking out of the loop if the input is valid and either exiting the program or repeating the process from the beginning. 
                    if (userCheck)
                    {
                        if (userNum == 0)
                            keepGoing = false;
                        finish = false;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease input a valid response.");
                    }
                }
            }

        }


        /// <summary>                     WCK- GOOD!
        /// method where the recursion is performed takes result int as input
        /// casts ints to string, pulls of the lest significant digit casts back to int, and adds           WCK- I would have used modulo
        /// two ints.  Once this is done checks to see if int is 1 digit if not recursion, if so break.
        /// </summary>
        /// <param name="num1"></param>                               WCK- oops. comments are not current with implementation
        /// <param name="num2"></param>
        /// <returns></returns>
        static int IntRecusion(int result)                             WCK- is it common practice for C# method names to start with capital letters?
        {
            //Converting the parameter into a string so it is easier to manipulate later in the code.
            string temp = Convert.ToString(result);

            //Removing the least significant digit from the number and removing it from the other numbers.
            char lastChar = temp[temp.Length - 1];
            string frontHalf = temp.Remove(temp.Length - 1, 1);

            //Converting both numbers back into integers in order to perform addition.
            int num2Add = Convert.ToInt32(frontHalf);
            int lastDigit = lastChar - '0';

            result = num2Add + lastDigit;

            //If the result has more than 1 digit then repeat the process recursively.
            if (result > 9)
                IntRecusion(result);                 WCK- shouldn't this be "result = IntRecursion(result);"; otherwise, I don't think this works.

            //Once final result is received print it out.
            if (result < 10)                             WCK- I'm not sure you need this if statement; look at the prior one.
                Console.WriteLine("\nResult: " + result);

            return result;

        }

        static void line()
        {
            string line = "";
            for(int i = 0; i < 85; i++)
            {
                line += '-';
            }

            Console.WriteLine(line);
        }
    }
}
