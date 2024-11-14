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
        eventMng.OnReplayEvent += OnReplayHandler;
    }

    void OnReplayHandler()
    {
        //Transaction pattern
        var resetLevelTransaction = TransactionFactory.Get<ResetLevelTransaction>();
        playerData.ExecuteTransaction(resetLevelTransaction);
    }
    private void CollectCoin()
    {
        //Transaction pattern
        var levelUpTransaction = TransactionFactory.Get<LevelUpTransaction>();
        playerData.ExecuteTransaction(levelUpTransaction);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        CollectCoin();
    }
}
