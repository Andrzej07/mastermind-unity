using System.Collections.Generic;

public class CodeBreakerBoardState
{
    public IReadOnlyList<CodeWithValidationResult> Guesses { get { return board.Guesses; } }

    private Board board;

    public CodeBreakerBoardState(Board board)
    {
        this.board = board;
    }
}