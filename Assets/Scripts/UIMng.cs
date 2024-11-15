using Injection;
using TMPro;
using UnityEngine;

public class UIMng : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    //DInjection pattern
    [Inject] IEventMng eventMng;
    
    void Start()
    {
        //DInjection pattern
        Initializer.Injector.Inject(this);
        
        //Observer pattern
        eventMng.ReplayEvent += OnReplayHandler;
        eventMng.PlayerLevelChangedEvent += OnPlayerLevelChangedHandler;
    }

    //Observer pattern
    void OnReplayHandler()
    {
        LevelText.text = $"Level 0";
    }
    
    void OnPlayerLevelChangedHandler(int level)
    {
        LevelText.text = $"Level {level}";
    }
}
