using UnityEngine;

public class ChangeColorCommand : ICommand
{
    private SpriteRenderer spriteRenderer;

    public bool IsUndoable => false;

    public ChangeColorCommand(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
    }

    public void Execute()
    {
        spriteRenderer.color = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }

    public void Undo() { }
}