using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        int grade = int.Parse(Console.ReadLine());

        string letterGrade;

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

        string letterSign = "";
    
        int letterGradeRange = grade % 10;

        if (letterGradeRange >= 7 && grade >= 60)
        {
            if (letterGrade != "A")
            {
                letterSign = "+";
            }
            else
            {
                letterSign = "";
            }
        }
        else if (letterGradeRange <= 3 && grade >= 60)
        {
            if (letterGrade != "F")
            {
                letterSign = "-";   
            }
            else
            {
                letterSign = "";
            }
        }

        Console.WriteLine($"Your letter grade is: {letterGrade}{letterSign}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the course.");
        }
    }
}