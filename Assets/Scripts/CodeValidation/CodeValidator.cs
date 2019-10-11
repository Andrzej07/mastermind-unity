using System;
using System.Collections.Generic;
using UnityEngine;

public class CodeValidator : MonoBehaviour
{
    private Code code;
    private IReadOnlyList<CodeColor> availableColors;

    public void Initialize(GameSettings gameSettings, Code code)
    {
        this.availableColors = gameSettings.Colors;
        this.code = code;
    }

    public CodeValidationResult ValidateCode(Code codeGuess)
    {
        if (code == null)
        {
            throw new Exception("Tried to validate code without initializing the validator!");
        }

        if (code.Length != codeGuess.Length)
        {
            throw new Exception("Tried to validate code that is different length!");
        }

        ColorPositions colorPositions = new ColorPositions(availableColors);
        int countPositionsCorrect = 0;
        int countColorsCorrect = 0;

        for (int i = 0; i < code.Length; i++)
        {
            CodeColor colorGuess = codeGuess[i];
            if (code.IsPositionValid(i, colorGuess))
            {
                countPositionsCorrect++;
            }
            else
            {
                int nextColorIdx = colorPositions.GetLastColorPosition(colorGuess) + 1;
                int foundIdx = code.PositionOf(colorGuess, nextColorIdx);
                if (foundIdx >= 0)
                {
                    colorPositions.SetLastColorPosition(colorGuess, foundIdx);
                    countColorsCorrect++;
                }
            }
        }

        return new CodeValidationResult(countPositionsCorrect == code.Length, countPositionsCorrect, countColorsCorrect);
    }

    private class ColorPositions
    {
        private Dictionary<CodeColor, int> colorPositions;

        public ColorPositions(IEnumerable<CodeColor> colors)
        {
            colorPositions = new Dictionary<CodeColor, int>();
            foreach (var color in colors)
            {
                colorPositions[color] = -1;
            }
        }

        public void SetLastColorPosition(CodeColor color, int position)
        {
            colorPositions[color] = position;
        }

        public int GetLastColorPosition(CodeColor color)
        {
            return colorPositions[color];
        }
    }
}