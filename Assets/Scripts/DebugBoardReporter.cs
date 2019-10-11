using UnityEngine;

public class DebugBoardReporter : MonoBehaviour
{
    [SerializeField]
    private Board board;

    private void Awake()
    {
        board.GuessAddedEvent += OnGuessAddedEvent;
    }

    private void OnGuessAddedEvent(CodeWithValidationResult codeWithValidation)
    {
        Debug.LogFormat("Added new guess to board: ({0}).", codeWithValidation.Code);
        var validation = codeWithValidation.ValidationResult;
        Debug.LogFormat("Is valid: {0}. Number of correct positions: {1}. Number of correct colors: {2}", validation.IsValid, validation.CountPositionsCorrect, validation.CountColorsCorrect);
    }
}
