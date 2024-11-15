using Injection;

public sealed class LevelUpTransaction: PlayerTransaction
{
    //DInjection pattern
    [Inject] IEventMng eventMng;
    
    public LevelUpTransaction()
    {
        //DInjection pattern
        Initializer.Injector.Inject(this);
    }
    
    //Transaction pattern
    public override void Execute(PlayerData playerData, object data = null)
    {
        int value = 0;
        //if data == null then value = 0 else value = (int)data
        if (data != null)
            value = (int) data;
        
        playerData.Level += value;
        eventMng.InvokePlayerLevelChangedEvent(playerData.Level);
        //Do other stuff that you want to do when the player levels up
    }
}
