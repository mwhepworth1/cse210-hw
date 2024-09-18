using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string gradePercentage = Console.ReadLine();
        int grade = int.Parse(gradePercentage);
        string letterGrade;

        if (grade >= 93)
        {
            letterGrade = "A";
        }
        else if (grade >= 90)
        {
            letterGrade = "A-";
        }
        else if (grade >= 87)
        {
            letterGrade = "B+";
        }
        else if (grade >= 83)
        {
            letterGrade = "B";
        }
        else if (grade >= 80)
        {
            letterGrade = "B-";
        }
        else if (grade >= 77)
        {
            letterGrade = "C+";
        }
        else if (grade >= 73)
        {
            letterGrade = "C";
        }
        else if (grade >= 70)
        {
            letterGrade = "C-";
        }
        else if (grade >= 67)
        {
            letterGrade = "D+";
        }
        else if (grade >= 63)
        {
            letterGrade = "D";
        }
        else if (grade >= 60)
        {
            letterGrade = "D-";
        }
        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"You got a(n) {letterGrade}!");

        if (grade >= 70)
        {
            Console.WriteLine("Also, congratulations on passing!");
        }
        else
        {
            Console.WriteLine("Sorry, it looks like you didn't pass this time.");
        }
    }
}