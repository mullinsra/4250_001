WCK - The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. You did most of this but there are some holes. It's okay. This is how we learn.
Question: did you write the design document first? It kind of looks like you wrote the code first then pasted it into your design doc.
    
WCK - some flaws in your design 
- not enough test data. you only account for one happy path.
Separateddigits = sum % 10
Sum = sum + separateddigits
- the above lines are flawed; Sum must have the LSD removed before you add them together.

This is NOT recursion. It is a loop. A recursion is a method that calls itself until a condition is met.

In general, this would appear to work. Nice. At least, for most happy paths. You need more test cases.
    

/* Team Chicken Nuggets
 * Dylan Shaffer
 * Tanner Collins
 * Jackson Coffey
*/
import java.util.Scanner;

public class recursion
{
    public static void main(String[] args)
    {
    //Digit's one and two take user input                                 WCK- Good. you comment these and initialize them and give meaningful names
    int digitOne = 0;
    int digitTwo = 0;
    //Holds the sum of digitOne and digitTwo
    int sumOfInput = 0;
    //Remainder is the least signifcant digit of sumOfInput
    int remainder = 0;
    //Remainder subtractged from sumOfInput
    int notRemainder = 0;
    //The final single-digit number
    int finalNumber = 10;
    
    //Scanner to take user input
    Scanner userInput = new Scanner(System.in);

    System.out.println("\nEnter a non-decimal number: ");
    digitOne = userInput.nextInt();  // Read user input                           WCK - what happens if user enters non-numeric value???

    System.out.println("\nEnter a second non-decimal number: ");
    digitTwo = userInput.nextInt();  // Read user input

    //Closing the scanner
    userInput.close();                      WCK- good. don't leave resources dangling

    //Adds user input together to get sum
    sumOfInput = digitOne + digitTwo;                           WCK- what if both are MaxInt or both are -MaxInt???

    while(finalNumber >= 9) //While loop repeats until finalNumber is down to 1 digit left
    {
        remainder = sumOfInput % 10; //Modulo 10 always returns the least significant digit in base 10

        //Separating the reaminder from the rest of the digits
        notRemainder = sumOfInput - remainder;
System.out.println("\n" + sumOfInput);
System.out.println(remainder);
System.out.println(notRemainder);
        //Drops the leftover 0
        notRemainder = notRemainder / 10; //Dividing by 10 drops the leftover 0              WCK- do you need the prior subtraction???

        //Takes the remainder plus the leftover digits, and adds them
        finalNumber = remainder + notRemainder;
        System.out.println(notRemainder);
        System.out.println(finalNumber);
    }                   

    System.out.println("\nThe final, single-digit number is: " + finalNumber + "\n");
    }
}
