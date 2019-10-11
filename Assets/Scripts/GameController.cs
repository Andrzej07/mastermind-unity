using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private CodeMaker codeMaker;
    [SerializeField]
    private CodeValidator codeValidator;
    [SerializeField]
    private CodeBreaker codeBreaker;
    [SerializeField]
    private Board board;
    [Header("Settings")]
    [SerializeField]
    private GameSettings gameSettings;

    private void Start()
    {
        board.Initialize(gameSettings);
        codeMaker.Initialize(gameSettings);
        codeBreaker.Initialize(gameSettings);
        codeMaker.CodeGeneratedEvent += OnCodeGenerated;
        codeBreaker.CodeGuessReadyEvent += OnCodeGuessReady;
        StartGame();
    }

    private void StartGame()
    {
        codeMaker.GenerateCode();
    }

    private void PlayRound()
    {
        var boardState = new CodeBreakerBoardState(board);
        codeBreaker.GuessCode(boardState);
    }

    private void CodeMakerVictory()
    {
        Debug.Log("Code maker wins!");
    }

    private void CodeBreakerVictory()
    {
        Debug.Log("Code breaker wins!");
    }

    private void OnCodeGenerated(Code generatedCode)
    {
        board.Clear();
        board.SetCode(generatedCode);
        codeValidator.Initialize(gameSettings, generatedCode);

        PlayRound();
    }

    private void OnCodeGuessReady(Code codeGuess)
    {
        CodeValidationResult codeValidationResult = codeValidator.ValidateCode(codeGuess);
        board.AddCodeGuess(codeGuess, codeValidationResult);

        if (codeValidationResult.IsValid)
        {
            CodeBreakerVictory();
        }
        else if (board.IsFull)
        {
            CodeMakerVictory();
        }
        else
        {
            PlayRound();
        }
    }
}
