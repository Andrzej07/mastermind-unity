public class CodeWithValidationResult
{
    public Code Code { get { return code; } }
    public CodeValidationResult ValidationResult { get { return validationResult; } }

    private Code code;
    private CodeValidationResult validationResult;

    public CodeWithValidationResult(Code code, CodeValidationResult validationResult)
    {
        this.code = code;
        this.validationResult = validationResult;
    }
}