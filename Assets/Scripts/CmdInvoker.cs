using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Injection;
using UnityEngine;

public class CmdInvoker: MonoBehaviour
{
    private Queue<Command> commandQueue = new();
    private Queue<Command> commandQueueReplay = new();
    private Stack<Command> undoStack = new();
    private Stack<Command> redoStack = new();
    private bool isExecuting = false;
    
    [Inject] IEventMng eventMng;

    private void Start()
    {
        Initializer.Injector.Inject(this);    
    }

    private void FromUndoStackToCommandQueueHistory()
    {
        //Reverse the stack and create the command queue history
        commandQueueReplay = new Queue<Command>(undoStack.Reverse());
    }

    public void Replay()
    {
        FromUndoStackToCommandQueueHistory();
        StartCoroutine(PlayReplay());
    }
    
    private IEnumerator PlayReplay()
    {
        eventMng.OnReplay();
        
        while (commandQueueReplay.Count > 0)
        {
            Command command = commandQueueReplay.Dequeue();
            yield return StartCoroutine(command.Execute());
        }
    }
    
    public void AddCommand(Command command)
    {
        commandQueue.Enqueue(command);
        if (!isExecuting)
        {
            StartCoroutine(ExecuteCommands());
        }
    }

    private IEnumerator ExecuteCommands()
    {
        isExecuting = true;

        while (commandQueue.Count > 0)
        {
            Command command = commandQueue.Dequeue();
            yield return StartCoroutine(command.Execute());
            undoStack.Push(command);
            redoStack.Clear(); // Clear redo stack when new command is executed
        }

        isExecuting = false;
    }

    public void Undo()
    {
        if (undoStack.Count > 0 && !isExecuting)
        {
            Command command = undoStack.Pop();
            StartCoroutine(UndoCommand(command));
        }
    }

    private IEnumerator UndoCommand(Command command)
    {
        isExecuting = true;
        yield return StartCoroutine(command.Undo());
        redoStack.Push(command);
        isExecuting = false;
    }

    public void Redo()
    {
        if (redoStack.Count > 0 && !isExecuting)
        {
            Command command = redoStack.Pop();
            StartCoroutine(RedoCommand(command));
        }
    }

    private IEnumerator RedoCommand(Command command)
    {
        isExecuting = true;
        yield return StartCoroutine(command.Execute());
        undoStack.Push(command);
        isExecuting = false;
    }   
}
