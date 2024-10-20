// See https://aka.ms/new-console-template for more information

string[] subjects = { "Math", "Science", "English", "History", "Art" };
int students;

Console.WriteLine("Enter the number of students you want to save: ");
string input = Console.ReadLine();

if (int.TryParse(input, out students) && !input.Contains("."))
{
    Console.WriteLine($"Number of students: {students}");
}
else
{
    Console.WriteLine("Invalid input. Please enter a whole number without decimal places.");
}

// Create a 2D array to store student grades
double[,] studentGrades = new double[students, subjects.Length];

// Input grades for each student and subject
for (int i = 0; i < students; i++)
{
    Console.WriteLine($"\nEnter grades for Student {i + 1}:");
    for (int j = 0; j < subjects.Length; j++)
    {
        Console.Write($"{subjects[j]}: ");
        while (!double.TryParse(Console.ReadLine(), out studentGrades[i, j]) || studentGrades[i, j] < 0 || studentGrades[i, j] > 6)
        {
            Console.Write("Invalid input. Please enter a grade between 1 and 6: ");
        }
    }
}

// Display the table with student grades and statistics
Console.WriteLine("\nStudent Grade Table:");
Console.WriteLine("Student\t\tHighest\tAverage\t" + string.Join("\t", subjects));

for (int i = 0; i < students; i++)
{
    double highest = double.MinValue;
    double sum = 0;

    for (int j = 0; j < subjects.Length; j++)
    {
        highest = Math.Max(highest, studentGrades[i, j]);
        sum += studentGrades[i, j];
    }

    double average = sum / subjects.Length;

    Console.Write($"Student {i + 1}\t{highest}\t{average}\t");

    for (int j = 0; j < subjects.Length; j++)
    {
        Console.Write($"{studentGrades[i, j]}\t");
    }

    Console.WriteLine();
}