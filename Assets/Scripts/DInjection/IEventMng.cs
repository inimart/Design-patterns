using System;
using Injection;

//DInjection pattern
public interface IEventMng: IInjectable
{
    delegate void ReplayDelegate();
    public event ReplayDelegate OnReplayEvent;
    public void OnPlayerLevelChanged(int level);
    public void OnReplay();
}
