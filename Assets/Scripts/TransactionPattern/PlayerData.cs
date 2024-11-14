
public class PlayerData: IPlayerData
{
    public int Level { get; set; }
    public void ExecuteTransaction(PlayerTransaction playerTransaction)
    {
        playerTransaction.Execute(this);
    }
}
