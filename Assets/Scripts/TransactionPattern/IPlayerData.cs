//Transaction pattern
public interface IPlayerData
{
    public int Level { get; }
    public void ExecuteTransaction(PlayerTransaction playerTransaction, object data = null);
}
