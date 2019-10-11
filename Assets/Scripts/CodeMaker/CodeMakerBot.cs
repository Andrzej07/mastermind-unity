using System;
using UnityEngine;

public class CodeMakerBot : CodeMaker
{
    public override event Action<Code> CodeGeneratedEvent = delegate { };

    public override void GenerateCode()
    {
        var codeColors = new CodeColor[codeLength];
        for (int i = 0; i < codeColors.Length; i++)
        {
            codeColors[i] = availableColors[0];
        }
        var code = new Code(codeColors);
        Debug.LogFormat("Generated code: {0}", code.ToString());
        CodeGeneratedEvent(code);
    }
}
