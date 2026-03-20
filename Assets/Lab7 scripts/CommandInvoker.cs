using UnityEngine;
using System.Collections.Generic;

public class CommandInvoker : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f;

    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ICommand cmd = new MoveLeftCommand(transform, moveDistance);
            ExecuteCommand(cmd);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ICommand cmd = new MoveRightCommand(transform, moveDistance);
            ExecuteCommand(cmd);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ICommand cmd = new ChangeColorCommand(spriteRenderer);
            ExecuteCommand(cmd);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastCommand();
        }
    }

    private void ExecuteCommand(ICommand command)
    {
        command.Execute();
        if (command.IsUndoable)
        {
            undoStack.Push(command);
            Debug.Log("Command stored. History count: " + undoStack.Count);
        }
        else
        {
            Debug.Log("Command executed (not undoable)");
        }
    }

    private void UndoLastCommand()
    {
        if (undoStack.Count > 0)
        {
            ICommand cmd = undoStack.Pop();
            cmd.Undo();
            Debug.Log("Undo! History count: " + undoStack.Count);
        }
        else
        {
            Debug.Log("Nothing to undo");
        }
    }
}