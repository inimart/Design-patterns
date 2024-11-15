using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class InputTester: MonoBehaviour
{
    public GameObject PlayerGO;
    public TrailRenderer trailRenderer;
    public GameObject crumbObj;
    
    private Vector3 initialPosition;
    private CmdInvoker cmdInvoker;
    private Transform t;
    private void Start()
    {
        initialPosition = PlayerGO.transform.position;
        cmdInvoker = GetComponent<CmdInvoker>();
        t = PlayerGO.transform;
    }

    //Create a public method foreach input
    public void MoveLeftInput()
    {
        var cmd = CommandFactory.Get<MoveCmd>();
        cmd.Initialize(t, Vector3.left);
        cmdInvoker.AddCommand(cmd);
    }
    
    public void MoveRightInput()
    {
        var cmd = CommandFactory.Get<MoveCmd>();
        cmd.Initialize(t, Vector3.right);
        cmdInvoker.AddCommand(cmd);
    }
    
    public void MoveForwardInput()
    {
        var cmd = CommandFactory.Get<MoveCmd>();
        cmd.Initialize(t, Vector3.forward);
        cmdInvoker.AddCommand(cmd);
    }
    
    public void MoveBackwardInput()
    {
        var cmd = CommandFactory.Get<MoveCmd>();
        cmd.Initialize(t, -Vector3.forward);
        cmdInvoker.AddCommand(cmd);
    }
    
    public void ReplayInput()
    {
        trailRenderer.Clear();
        trailRenderer.enabled = false;
        PlayerGO.transform.position = initialPosition;
        trailRenderer.enabled = true;
        StartReplay();
    }
    
    public void UndoInput()
    {
        cmdInvoker.Undo();
    }
    
    public void RedoInput()
    {
        cmdInvoker.Redo();
    }
    
    private void Update()
    {
    }
    
    public void StartReplay()
    {
        cmdInvoker.Replay();
    }
}
