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
    //Digit's one and two take user input
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
    digitOne = userInput.nextInt();  // Read user input

    System.out.println("\nEnter a second non-decimal number: ");
    digitTwo = userInput.nextInt();  // Read user input

    //Closing the scanner
    userInput.close();

    //Adds user input together to get sum
    sumOfInput = digitOne + digitTwo;

    while(finalNumber >= 9) //While loop repeats until finalNumber is down to 1 digit left
    {
        remainder = sumOfInput % 10; //Modulo 10 always returns the least significant digit in base 10

        //Separating the reaminder from the rest of the digits
        notRemainder = sumOfInput - remainder;
System.out.println("\n" + sumOfInput);
System.out.println(remainder);
System.out.println(notRemainder);
        //Drops the leftover 0
        notRemainder = notRemainder / 10; //Dividing by 10 drops the leftover 0

        //Takes the remainder plus the leftover digits, and adds them
        finalNumber = remainder + notRemainder;
        System.out.println(notRemainder);
        System.out.println(finalNumber);
    }

    System.out.println("\nThe final, single-digit number is: " + finalNumber + "\n");
    }
}
