using System;
using TMPro;
using UnityEngine;

public class EventMng : MonoBehaviour, IEventMng
{
    //Observer pattern
    public event IEventMng.ReplayDelegate ReplayEvent;
    public event IEventMng.LevelChangedDelegate PlayerLevelChangedEvent;

    public void InvokePlayerLevelChangedEvent(int level)
    {
        PlayerLevelChangedEvent?.Invoke(level);
    }
    public void InvokeReplayEvent()
    {
        InvokePlayerLevelChangedEvent(0);
        ReplayEvent?.Invoke();
    }
}
