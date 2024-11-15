using System;
using Injection;

//DInjection pattern
public interface IEventMng: IInjectable
{
    //Observer pattern
    delegate void ReplayDelegate();
    delegate void LevelChangedDelegate(int level);
    public event ReplayDelegate ReplayEvent;
    public event LevelChangedDelegate PlayerLevelChangedEvent;
    public void InvokePlayerLevelChangedEvent(int level);
    public void InvokeReplayEvent();
}
