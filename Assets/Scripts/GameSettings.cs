using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mastermind/Game Settings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private int maxGuessCount = 7;
    [SerializeField]
    private int codeLength = 4;
    [SerializeField]
    private CodeColor[] colors;

    public IReadOnlyList<CodeColor> Colors { get { return colors; } }
    public int MaxGuessCount { get { return maxGuessCount; } }
    public int CodeLength { get { return codeLength; } }
}
