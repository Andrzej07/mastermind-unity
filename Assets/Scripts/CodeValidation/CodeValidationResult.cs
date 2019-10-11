public class CodeValidationResult
{
    public bool IsValid { get { return isValid; } }
    public int CountPositionsCorrect { get { return countPositionsCorrect; } }
    public int CountColorsCorrect { get { return countColorsCorrect; } }

    private bool isValid;
    private int countPositionsCorrect;
    private int countColorsCorrect;

    public CodeValidationResult(bool isValid, int countPositionsCorrect, int countColorsCorrect)
    {
        this.isValid = isValid;
        this.countPositionsCorrect = countPositionsCorrect;
        this.countColorsCorrect = countColorsCorrect;
    }
}