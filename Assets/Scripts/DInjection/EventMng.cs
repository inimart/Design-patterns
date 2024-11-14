using System;
using TMPro;
using UnityEngine;

public class EventMng : MonoBehaviour, IEventMng
{
    public TextMeshProUGUI LevelText;
    public GameObject Coins;
    public event IEventMng.ReplayDelegate OnReplayEvent;
    GameObject currentCoins;

    void InstantiateCoins()
    {
        currentCoins = Instantiate(Coins, new Vector3(0, 0, 0), Quaternion.identity);
    }
    private void Start()
    {
        InstantiateCoins();
    }

    public void OnPlayerLevelChanged(int level)
    {
        LevelText.text = $"Level {level.ToString()}";
    }
    public void OnReplay()
    {
        //Destroy current Coins and instantiate new ones
        Destroy(currentCoins);
        InstantiateCoins();
        OnPlayerLevelChanged(0);
        OnReplayEvent?.Invoke();
    }
}
