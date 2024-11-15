using System;
using TMPro;
using UnityEngine;

public class EventMng : MonoBehaviour, IEventMng
{
    public event IEventMng.ReplayDelegate ReplayEvent;

    public void InvokePlayerLevelChangedEvent(int level)
    {
    }
    public void InvokeReplayEvent()
    {
        InvokePlayerLevelChangedEvent(0);
        ReplayEvent?.Invoke();
    }
}
