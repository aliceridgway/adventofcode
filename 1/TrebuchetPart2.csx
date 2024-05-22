string filePath = "1/input.txt";

public class Trebuchet
{
    public Dictionary<string, string> Numbers { get; private set; }
    public Trebuchet()
    {
        Numbers = new Dictionary<string, string>
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };
    }
    public int GetCalibrationValue(string line, int lineNumber)
    {
        string lastNumber = "";
        string firstNumber = "";

        int lowestIndex = line.Length;
        int highestIndex = -1;

        foreach (var (number, digit) in Numbers)
        {
            int firstIndexNumber = line.IndexOf(number);
            int firstIndexDigit = line.IndexOf(digit);

            int lastIndexDigit = line.LastIndexOf(digit);
            int lastIndexNumber = line.LastIndexOf(number);

            if (lastIndexDigit > highestIndex)
            {
                highestIndex = lastIndexDigit;
                lastNumber = digit;
            }

            if (lastIndexNumber > highestIndex)
            {
                highestIndex = lastIndexNumber;
                lastNumber = Numbers[number];
            }

            if (firstIndexDigit > -1 && firstIndexDigit < lowestIndex)
            {
                lowestIndex = firstIndexDigit;
                firstNumber = digit;
            }

            if (firstIndexNumber > -1 && firstIndexNumber < lowestIndex)
            {
                lowestIndex = firstIndexNumber;
                firstNumber = Numbers[number];
            }
        }

        int calibrationValue = int.Parse($"{firstNumber}{lastNumber}");

        Console.WriteLine($"{lineNumber}: {calibrationValue}    {line}");

        return calibrationValue;
    }
}

int total = 0;
int lineNumber = 1;

Trebuchet trebuchet = new Trebuchet();

foreach (string line in File.ReadLines(filePath))
{
    int calibrationValue = trebuchet.GetCalibrationValue(line, lineNumber);

    lineNumber += 1;
    total += calibrationValue;
}

Console.WriteLine(total);