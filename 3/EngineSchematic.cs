using System.Text.RegularExpressions;

public class Border
{
    private int rowIndex;
    private int columnIndex;
    private int length;

    public Border(int rowIndex, int columnIndex, int length)
    {
        this.rowIndex = rowIndex;
        this.columnIndex = columnIndex;
        this.length = length;
    }
}

class BorderFactory
{
    private int rowIndex;
    private int columnIndex;
    private int length;
    private int minimumRowIndex;
    private int maximumRowIndex;
    private int minimumColumnIndex;
    private int maximumColumnIndex;

    public BorderFactory(
        int rowIndex,
        int columnIndex,
        int length,
        int minimumRowIndex,
        int maximumRowIndex,
        int minimumColumnIndex,
        int maximumColumnIndex
    )
    {
        this.rowIndex = rowIndex;
        this.columnIndex = columnIndex;
        this.length = length;
        this.minimumRowIndex = minimumRowIndex;
        this.maximumRowIndex = maximumRowIndex;
        this.minimumColumnIndex = minimumColumnIndex;
        this.maximumColumnIndex = maximumColumnIndex;

    }

    private Border topBorder()
    {
        int topBorderRowIndex = rowIndex - 1;
        int startColumnIndex = Math.Max(columnIndex, minimumColumnIndex);
        int endColumnIndex = Math.Min(startColumnIndex + length + 1, maximumColumnIndex);

        int borderLength = endColumnIndex - startColumnIndex;

        return new Border(topBorderRowIndex, startColumnIndex, borderLength);
    }

    private Border leftBorder()
    {
        return new Border(rowIndex, columnIndex - 1, 1);
    }

    private Border rightBorder()
    {
        return new Border(rowIndex, columnIndex + length + 1, 1);
    }

    private Border bottomBorder()
    {
        int startColumnIndex = Math.Max(columnIndex, minimumColumnIndex);
        int endColumnIndex = Math.Min(startColumnIndex + length + 1, maximumColumnIndex);
        int borderLength = endColumnIndex - startColumnIndex;

        return new Border(rowIndex + 1, startColumnIndex, borderLength);
    }
    private bool hasTopBorder()
    {
        return rowIndex > minimumRowIndex;
    }

    private bool hasBottomBorder()
    {
        return rowIndex < maximumRowIndex;
    }

    private bool hasLeftBorder()
    {
        return columnIndex > minimumColumnIndex;
    }

    private bool hasRightBorder()
    {
        return columnIndex + length < maximumColumnIndex;
    }

    public List<Border> getBorders()
    {
        List<Border> borders = new List<Border>();

        if (hasTopBorder())
        {
            borders.Add(topBorder());
        }

        if (hasLeftBorder())
        {
            borders.Add(leftBorder());
        }

        if (hasRightBorder())
        {
            borders.Add(rightBorder());
        }

        if (hasBottomBorder())
        {
            borders.Add(bottomBorder());
        }

        return borders;
    }
}
public class Line
{
    private string line;
    private int rowIndex;

    public int RowIndex => rowIndex;
    public string LineString => line;

    public Line(string line, int rowIndex)
    {
        this.line = line;
        this.rowIndex = rowIndex;
    }

}

public class Number
{
    private string number;
    private Line line;
    private int columnIndex;

    public Number(string number, Line line, int columnIndex)
    {
        this.number = number;
        this.line = line;
        this.columnIndex = columnIndex;
    }

    public List<Border> getBorders(int minimumColumnIndex, int maximumColumnIndex, int minimumRowIndex, int maximumRowIndex)
    {

        List<Border> borders = new List<Border>();

        return new BorderFactory(
            columnIndex,
            line.RowIndex,
            number.Length,
            minimumRowIndex,
            maximumRowIndex,
            minimumColumnIndex,
            maximumColumnIndex
        ).getBorders();
    }
}

public class NumberFactory
{
    private string pattern = @"\d+";
    private Line line;

    public NumberFactory(Line line)
    {
        this.line = line;
    }

    public List<Number> getNumbers()
    {
        List<Number> numbers = new List<Number>();

        MatchCollection matches = Regex.Matches(line.LineString, pattern);

        foreach (Match match in matches)
        {
            string number = match.Value;
            int startingIndex = line.LineString.IndexOf(number);

            numbers.Add(new Number(number, line, startingIndex));
        }

        return numbers;
    }
}


public class EngineSchematic
{
    private int lineCount;
    private int lineLength;
    private List<string> lines;

    public int MinimumColumnIndex = 0;
    public int MaximumColumnIndex => lineLength - 1;
    public int MinimumRowIndex = 0;
    public int MaximumRowIndex => lineCount - 1;

    public EngineSchematic(List<string> lines)
    {
        this.lines = lines;
        this.lineCount = lines.Count;
        this.lineLength = lines[0].Length;
    }

    public string line(int index)
    {
        return lines[index];
    }
}