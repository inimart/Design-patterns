using Injection;
using UnityEngine;

public class LevelBuilder: MonoBehaviour
{
    [Inject] IEventMng eventMng;
    GameObject currentCoins;
    public GameObject Coins;

    void InstantiateCoins()
    {
        currentCoins = Instantiate(Coins, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void Start()
    {
        Initializer.Injector.Inject(this);    
        
        eventMng.ReplayEvent += OnReplayHandler;

        InstantiateCoins();
    }
    
    private void OnReplayHandler()
    {
        //Destroy current Coins and instantiate new ones
        Destroy(currentCoins);
        InstantiateCoins();
    }
}
