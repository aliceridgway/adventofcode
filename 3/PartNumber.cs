public class Border
{
    int lineNumber;
    int startingIndex;
    int length;

    public Border(int lineNumber, int startingIndex, int length)
    {
        this.lineNumber = lineNumber;
        this.startingIndex = startingIndex;
        this.length = length;
    }
}

public class PartNumber
{
    private string partNumber;
    private int lineNumber;
    private int startingIndex;
    private int endIndex;

    EngineSchematic schematic;

    public PartNumber(string partNumber, int lineNumber, int startingIndex, EngineSchematic schematic)
    {
        this.partNumber = partNumber;
        this.lineNumber = lineNumber;
        this.startingIndex = startingIndex;
        this.endIndex = startingIndex + partNumber.Length;
        this.schematic = schematic;
    }

    public List<Border> getBorders()
    {
        var borders = new List<Border>();

        return borders;
    }
}