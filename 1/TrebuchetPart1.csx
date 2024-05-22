using System.IO;
using System.Linq;

string filePath = "1/input.txt";

int total = 0;

foreach (string line in File.ReadLines(filePath))
{
    char[] digits = line.Where(char.IsDigit).ToArray();
    char firstDigit = digits[0];
    char lastDigit = digits.Last();

    int calibrationValue = int.Parse($"{firstDigit}{lastDigit}");

    total += calibrationValue;
}

Console.WriteLine(total);