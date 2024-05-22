using System.Text.RegularExpressions;
using System.Linq;

string filePath = "2/input.txt";
public class Game
{
    private string[] colours;
    private string game;

    public Game(string[] colours, string game)
    {
        this.colours = colours;
        this.game = game;
    }

    public int getPower()
    {
        int power = 1;

        foreach (string colour in colours)
        {
            int maxOfColour = maximumBallsDrawnOfColour(colour);

            power = power * maxOfColour;
        }

        return power;
    }
    private int maximumBallsDrawnOfColour(string colour)
    {
        string regexNumberPrecedingColour = $@"\b\d+\b(?=\s*{colour})";

        MatchCollection ballCounts = Regex.Matches(game, regexNumberPrecedingColour);

        int[] counts = ballCounts.Cast<Match>().Select(match => int.Parse(match.Value)).ToArray();

        return counts.Max();
    }

}

int total = 0;
string[] colours = { "red", "green", "blue" };

foreach (string line in File.ReadLines(filePath))
{
    Game game = new Game(colours, line);
    int power = game.getPower();

    total += power;
}

Console.WriteLine($"The total powers for games is {total}");