#load "EngineSchematic.cs"

using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;


string filePath = "3/input.txt";

List<string> lines = File.ReadLines(filePath).ToList();

EngineSchematic schematic = new EngineSchematic(lines);

for (int i = schematic.MinimumRowIndex; i <= schematic.MaximumRowIndex; i++)
{
    Line line = new Line(schematic.line(i), i);
    List<Number> numbers = new NumberFactory(line).getNumbers();
}

