
public class PlayerData: IPlayerData
{
    public int Level { get; set; }
    public void ExecuteTransaction(PlayerTransaction playerTransaction, object data = null)
    {
        playerTransaction.Execute(this, data);
    }
}
