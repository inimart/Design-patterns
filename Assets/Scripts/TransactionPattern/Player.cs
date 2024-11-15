using System;
using Injection;
using UnityEngine;

public class Player: MonoBehaviour
{
    //Transaction pattern
    public IPlayerData playerData = new PlayerData();
    [Inject] IEventMng eventMng;
    
    private void Start()
    {
        Initializer.Injector.Inject(this);
        eventMng.ReplayEvent += OnReplayHandler;
    }

    void OnReplayHandler()
    {
        //Transaction pattern
        var resetLevelTransaction = TransactionFactory.Get<ResetLevelTransaction>();
        playerData.ExecuteTransaction(resetLevelTransaction);
    }
    private void CollectCoin(int points)
    {
        //Transaction pattern
        var levelUpTransaction = TransactionFactory.Get<LevelUpTransaction>();
        playerData.ExecuteTransaction(levelUpTransaction, points);
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinData coinData = other.GetComponent<Coin>().Data;
        CollectCoin(coinData.points);
        Destroy(other.gameObject);
    }
}
