using System;
using Injection;

//DInjection pattern
public interface IEventMng: IInjectable
{
    delegate void ReplayDelegate();
    delegate void LevelChangedDelegate();
    public event ReplayDelegate ReplayEvent;
    public event LevelChangedDelegate PlayerLevelChangedEvent;
    public void InvokePlayerLevelChangedEvent(int level);
    public void InvokeReplayEvent();
}
