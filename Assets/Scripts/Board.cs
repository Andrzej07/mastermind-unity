using System;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public event Action<Code> CodeChangedEvent = delegate { };
    public event Action<CodeWithValidationResult> GuessAddedEvent = delegate { };
    public event Action BoardClearedEvent = delegate { };

    public bool IsFull { get { return boardSize == guesses.Count; } }
    public IReadOnlyList<CodeWithValidationResult> Guesses { get { return guesses; } }

    private int boardSize;
    private Code code;
    private List<CodeWithValidationResult> guesses;

    public void Initialize(GameSettings gameSettings)
    {
        this.boardSize = gameSettings.MaxGuessCount;
        guesses = new List<CodeWithValidationResult>(boardSize);
    }

    public void Clear()
    {
        code = null;
        guesses.Clear();
        BoardClearedEvent();
    }

    public void SetCode(Code code)
    {
        this.code = code;
        CodeChangedEvent(code);
    }

    public void AddCodeGuess(Code codeGuess, CodeValidationResult codeValidationResult)
    {
        if (guesses.Count == boardSize)
        {
            throw new Exception("Tried to add new guess to a full board!");
        }
        var codeWithValidation = new CodeWithValidationResult(codeGuess, codeValidationResult);
        guesses.Add(codeWithValidation);
        GuessAddedEvent(codeWithValidation);
    }
}