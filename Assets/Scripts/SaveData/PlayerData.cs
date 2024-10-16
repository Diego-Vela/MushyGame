[System.Serializable] // Mark this class as serializable
public class PlayerData
{
    public float[] position;

    // Constructor that captures player’s position
    public PlayerData(Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
