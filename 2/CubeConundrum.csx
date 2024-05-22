using System.Text.RegularExpressions;

string filePath = "2/input.txt";
public class Game
{
    private Dictionary<string, int> balls;
    private string game;

    public Game(Dictionary<string, int> balls, string game)
    {
        this.balls = balls;
        this.game = game;
    }

    public int getId()
    {
        string[] parts = game.Split(":");
        string gameNumber = parts[0].Trim().Split(" ")[1];

        return int.Parse(gameNumber);
    }

    public bool isValid()
    {
        bool gameIsPossible = true;

        foreach (var (colour, maxAllowed) in balls)
        {
            string regexNumberPrecedingColour = $@"\b\d+\b(?=\s*{colour})";

            MatchCollection ballCounts = Regex.Matches(game, regexNumberPrecedingColour);

            // Iterate through matches and print the numbers
            foreach (Match match in ballCounts)
            {

                int ballCountOfColour = int.Parse(match.Value);

                if (ballCountOfColour > maxAllowed)
                {
                    gameIsPossible = false;
                }
            }
        }

        return gameIsPossible;
    }
}

Dictionary<string, int> balls = new Dictionary<string, int>
{
    { "green", 13 },
    { "red", 12 },
    { "blue", 14 }
};

int total = 0;

foreach (string line in File.ReadLines(filePath))
{
    Game game = new Game(balls, line);

    bool gameIsValid = game.isValid();

    if (!gameIsValid)
    {
        continue;
    }

    int gameID = game.getId();
    total += gameID;
}

Console.WriteLine($"The total game IDs for feasible games is {total}");