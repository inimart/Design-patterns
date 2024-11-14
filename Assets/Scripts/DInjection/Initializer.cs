using System;
using Injection;
using UnityEngine;

public class Initializer: MonoBehaviour
{
    public static Injector Injector;

    private void Awake()
    {
        EventMng eventMng = FindFirstObjectByType<EventMng>();
        
        //DInjection pattern
        Injector = new Injector();
        Injector.Bind<IEventMng>(eventMng);
    }
    
    
}
