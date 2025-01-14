using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string letterGrade;
        string gradeSign = "";

        // Determine the letter grade
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Add "+" or "-" sign for grades except F
        if (letterGrade != "F")
        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                gradeSign = "+";
            }
            else if (lastDigit < 3)
            {
                gradeSign = "-";
            }

            // Ensure "A+" does not exist
            if (letterGrade == "A" && gradeSign == "+")
            {
                gradeSign = "";
            }
        }

        // Print the final grade
        Console.WriteLine($"Your letter grade is: {letterGrade}{gradeSign}");

        // Check if the student passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Don't worry, you'll do better next time!");
        }
    }
}
