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
    public override void Execute(PlayerData playerData)
    {
        playerData.Level++;
        eventMng.OnPlayerLevelChanged(playerData.Level);
        //Do other stuff that you want to do when the player levels up
    }
}
