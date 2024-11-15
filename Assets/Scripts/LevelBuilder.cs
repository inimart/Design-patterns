using Injection;
using UnityEngine;

public class LevelBuilder: MonoBehaviour
{
    [Inject] IEventMng eventMng;
    GameObject currentCoins;
    public GameObject Coins;

    private void Start()
    {
        Initializer.Injector.Inject(this);    
        
        eventMng.ReplayEvent += OnReplayHandler;

        InstantiateCoins();
    }
    
    void InstantiateCoins()
    {
        currentCoins = Instantiate(Coins, new Vector3(0, 0, 0), Quaternion.identity);
    }
    private void OnReplayHandler()
    {
        //Destroy current Coins and instantiate new ones
        Destroy(currentCoins);
        InstantiateCoins();
    }
}
