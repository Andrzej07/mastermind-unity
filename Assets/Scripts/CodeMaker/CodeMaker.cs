using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CodeMaker : MonoBehaviour
{
    public abstract event Action<Code> CodeGeneratedEvent;
    public abstract void GenerateCode();

    protected int codeLength;
    protected IReadOnlyList<CodeColor> availableColors;

    public void Initialize(GameSettings gameSettings)
    {
        this.codeLength = gameSettings.CodeLength;
        this.availableColors = gameSettings.Colors;
    }
}