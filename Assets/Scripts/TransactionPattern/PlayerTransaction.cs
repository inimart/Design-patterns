//Transaction pattern
public abstract class PlayerTransaction
{
    public abstract void Execute(PlayerData playerData, object data = null);
}
