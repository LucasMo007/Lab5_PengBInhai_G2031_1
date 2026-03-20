using UnityEngine;

public class MoveLeftCommand : ICommand
{
    private Transform player;
    private Vector3 previousPosition;
    private float distance;

    public bool IsUndoable => true;

    public MoveLeftCommand(Transform player, float distance = 1f)
    {
        this.player = player;
        this.distance = distance;
    }

    public void Execute()
    {
        previousPosition = player.position;
        player.position += Vector3.left * distance;
    }

    public void Undo()
    {
        player.position = previousPosition;
    }
}
