using Injection;

public sealed class ResetLevelTransaction: PlayerTransaction
{
    public ResetLevelTransaction()
    {
        //DInjection pattern
        Initializer.Injector.Inject(this);
    }
    
    //Transaction pattern
    public override void Execute(PlayerData playerData, object data = null)
    {
        playerData.Level = 0;
    }
}