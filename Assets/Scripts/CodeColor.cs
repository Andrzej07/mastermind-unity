using UnityEngine;

[CreateAssetMenu(menuName = "Mastermind/Code Color")]
public class CodeColor : ScriptableObject
{
    public Color Color { get { return color; } }

    [SerializeField]
    private Color color;
}
