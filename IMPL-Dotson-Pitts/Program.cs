WCK-  The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. You did some of these.
    
WCK- some concerns about the design.
    4556465 + 57658 = 4614123, 461412 + 3 = 461412 (the last one is not true; did you forget to continue your thought?)
    there is no test cases or discussion of boundary conditions or constraints on the inputs.

    Additional comments below prefixed with WCK-

/*
    Team Name: The Three... Two Stooges
    Actual Names: Daniel Dotson, Timothy Pitts
    Class CSCI 4250_001
    Assignment: In class implementation exercise
    Date: 9/27/2022
*/

public class Program
{
    //The main method initates a program that loops until the user enters the exit option. The input is take as a string
    //and sent to the case as a string. But the switch statement returns an integer so that an exit condition (x = 2) is reached.

    public static void Main()
    {
        int x = 0;                        WCK- good, you initialized it. But is "x" the best descriptive name you can have here?
                                              I would have named it "endProgram = false" and switchCase returns false if they choose 2 or returns true otherwise
                                                  then it reads while (!endProgram)
        do
        {   
            //get users main menu choice as a string.
            string userInput = Program.mainMenu();

            //send users input string to switch case.
            x = switchCase(userInput);


        } while (x != 2); //exit condition is x=2, which will be reached when the user inputs "2"
    }

    //This displays the main menu and returns the users input as a string. 
    public static string mainMenu()
    {
        //prints out menu. 
        Console.WriteLine("1: Run recursive program");
        Console.WriteLine("2: Exit");
        Console.WriteLine("Enter the number next to your choice: ");
        
        //TODO deal with Null input.
        string input = Console.ReadLine(); //sends user input back as a string.
        return input;
    }

    //This number 
    public static int switchCase(string input)
    {
        switch(input)
        {
            case "1":
                // call method for running recursion
                return 1;
            case "2":
                //return 2 to exit do while condition
                return 2;
            default:
                //This shows that the user has put in invalid options. The Main method is called to 
                //restart the program. 
                Console.WriteLine("not a valid option");
                Main();                             WCK- I think this is flawed logic. You should not recursively call Main. And by returning 0
                                                           I'm pretty you end up calling mainMenu again which is okay if you haven't already called Main again.
                                                        just return zero here
                return 0;
        }

        //TODO: Recursion main program. Needs to loop through input until input is valid.
    }



}


