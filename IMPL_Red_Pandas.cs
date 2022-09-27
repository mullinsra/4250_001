/***
 * 

Implementation for the project

Cory Windham
Ty Seiber
Ethan Morgan

Recursion

Definition of Done - break out of the loop and print one number. (exceptions for max int, not int, and null)

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
            string line = "----------------------------------------------------";                       //to make pretty
            bool start = false;                                                                         //used for while loop
            bool intCheck1 = false;                                                                     //bools to check if nums are actualy ints
            bool intCheck2 = false;                                                                     //bools to check if nums are actualy ints
            int num1 = 0;
            int num2 = 0;
            var num1_check = " n";                                                                      //initial variables taken in to check
            var num2_check = " n";                                                                      //initial variables taken in to check
            int max = int.MaxValue;                                                                     //check for max number
            

            //start program
            Console.WriteLine("This program will take two numbers as input, and recursively\n" +
                "separarte off the lest significant digit and add it bac to the previous.  \n" +
                "if the reuslt is 1 digit it will be returned and printed");
            while (start == false)
            {
                //num1 
                Console.WriteLine("Enter a positive number: ");

                //int check
                num1_check = Console.ReadLine();
                intCheck1 = int.TryParse(num1_check, out num1);

                //num2
                Console.WriteLine("Enter a positive number: ");

                //int check
                num2_check = Console.ReadLine();
                intCheck2 = int.TryParse(num2_check, out num2);


                //condition to get out of while loop
                if (intCheck1 && intCheck2 && num1 < max && num2 < max && num1 >= 0 && num2 >= 0)

                    start = true;
                //exception
                else
                    Console.WriteLine(line + "\nOops looks like something was wrong remember to input a positive number " +
                        "\n(hint: letters are not numbers)\n" + line);
    
            }

            //after loop add nums
            int result = num1 + num2;

            result = IntRecusion(result);   
 

            Console.WriteLine("Result: {0}");

            Console.ReadKey();

        }


        /// <summary>
        /// method where the recursion is performed takes result int as input
        /// casts ints to string, pulls of the lest significant digit casts back to int, and adds 
        /// two ints.  Once this is done checks to see if int is 1 digit if not recursion, if so break.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static int IntRecusion(int result)
        {

            //
            string temp = Convert.ToString(result);

            char lastChar = temp[temp.Length - 1];
            string frontHalf = temp.Remove(temp.Length - 1, 1);

            Console.WriteLine(lastChar);
            Console.WriteLine(frontHalf); 
            

            int num2add1 = Convert.ToInt32(frontHalf);
            int num2add2 = Convert.ToInt32(lastChar);
            
            

            Console.WriteLine(num2add1);
            Console.WriteLine(num2add2);

            result = num2add1 + num2add2;

            //if (result > 9)
            // IntRecusion(result);


            return result;

        }
    }
}
