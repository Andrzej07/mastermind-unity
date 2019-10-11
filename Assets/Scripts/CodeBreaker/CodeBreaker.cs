using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CodeBreaker : MonoBehaviour
{
    public abstract event Action<Code> CodeGuessReadyEvent;
    public abstract void GuessCode(CodeBreakerBoardState currentBoardState);

    protected int codeLength;
    protected int maxGuessCount;
    protected IReadOnlyList<CodeColor> availableColors;

    public void Initialize(GameSettings gameSettings)
    {
        this.codeLength = gameSettings.CodeLength;
        this.maxGuessCount = gameSettings.MaxGuessCount;
        this.availableColors = gameSettings.Colors;
    }
}