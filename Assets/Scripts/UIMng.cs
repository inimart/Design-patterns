using Injection;
using TMPro;
using UnityEngine;

public class UIMng : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    [Inject] IEventMng eventMng;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventMng.ReplayEvent += OnReplayHandler;
        eventMng.PlayerLevelChangedEvent += OnPlayerLevelChangedHandler;
        
    }

    void OnReplayHandler()
    {
        LevelText.text = $"Level 0";
    }
    
    void OnPlayerLevelChangedHandler(int level)
    {
        LevelText.text = $"Level {level}";
    }
}
