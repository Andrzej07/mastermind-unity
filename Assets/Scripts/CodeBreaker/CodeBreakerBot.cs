using System;
using System.Collections.Generic;

public class CodeBreakerBot : CodeBreaker
{
    public override event Action<Code> CodeGuessReadyEvent = delegate { };

    public override void GuessCode(CodeBreakerBoardState currentBoardState)
    {
        var colors = new List<CodeColor>();
        for (int i = 0; i < codeLength; i++)
        {
            colors.Add(availableColors[i % availableColors.Count]);
        }
        Code guess = new Code(colors);
        CodeGuessReadyEvent(guess);
    }
}
