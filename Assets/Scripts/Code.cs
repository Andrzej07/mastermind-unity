using System.Collections.Generic;
using System.Text;

public class Code
{
    public IReadOnlyCollection<CodeColor> Colors { get { return colors; } }
    public int Length { get { return colors.Count; } }
    public CodeColor this[int i]
    {
        get { return colors[i]; }
    }

    private List<CodeColor> colors;
    private string stringified;

    public Code(ICollection<CodeColor> colors)
    {
        this.colors = new List<CodeColor>(colors);
        stringified = BuildCodeString();
    }

    public bool IsPositionValid(int index, CodeColor color)
    {
        return colors[index] == color;
    }

    public int PositionOf(CodeColor color, int startIndex = 0)
    {
        return colors.IndexOf(color, startIndex);
    }

    public override string ToString()
    {
        return stringified;
    }

    private string BuildCodeString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < colors.Count; i++)
        {
            sb.Append(colors[i].name);
            if (i < colors.Count - 1)
                sb.Append(", ");
        }

        return sb.ToString();
    }
}