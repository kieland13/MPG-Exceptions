using System;

namespace FormatExceptions
{
   class Program
   {
      static void Main(string[] args)
      {
         //create a bool variable to check if the loop has been completed
         var loopVariable = true;

         //do loop until the while validation is false
         do
         {
            try
            {
               //ask user how many miles they drove
               Console.Write("How many miles did you drive?");
               decimal milesDriven = Convert.ToDecimal(Console.ReadLine());
               //converted the string to a decimal

               //validate the miles drove is a postive number, if not post message and ask again
               while (milesDriven < 0)
               {
                  Console.WriteLine("Cannot drive a negative amount of miles. Please re-enter a number.");
                  milesDriven = Convert.ToDecimal(Console.ReadLine());
               }

               //ask user for how many gallons were used
               Console.Write("How many gallons were used?");
               decimal gallonsUsed = Convert.ToDecimal(Console.ReadLine());
               //converted the string to decimal

               //validate the gallons used were a positive numebr, if not, post message and ask again
               while (gallonsUsed < 0)
               {
                  Console.WriteLine("Cannot use a negative amount of gallons. Please re-enter a number.");
                  gallonsUsed = Convert.ToDecimal(Console.ReadLine());
               }

               //calculate MPG
               decimal milesPerGallon = (milesDriven / gallonsUsed);

               //print off results of the MPG
               Console.WriteLine($"\nMPG: {milesDriven} / {gallonsUsed} = {milesPerGallon:f2} miles per gallon");
               loopVariable = false;
            }

            //catching the format exception
            //making sure numbers were typed in instead of words
            catch (FormatException formatException)
            {
               //print messages if exception was caught
               Console.WriteLine($"\n{formatException.Message}");
               Console.WriteLine("You must enter two valid numbers. You cannot type in words for numbers. Please Try again.\n");
            }

            //catching the overflow exception
            //making sure the numbers werent too big or small to be an int
            catch (OverflowException overflowException)
            {
               //print messages if exceptions were caught
               Console.WriteLine($"\n{overflowException.Message}");
               Console.WriteLine("The number you entered was either too big or too small. Please enter a number again.\n");
            }

            //catching the divebyzero exception
            //making sure the MPG cannot be divided by zero, which is impossible to calculate
            catch (DivideByZeroException divideByZeroException)
            {

               //print messages if exceptions were caught
               Console.WriteLine($"\n{divideByZeroException.Message}");
               Console.WriteLine("Zero is an invalid mile per gallon. Cannot divide by zero. Please try again.\n");
            }
         } while (loopVariable);
         //run program until the loop varibale is false, which means no exceptions happened
      }
   }
}
