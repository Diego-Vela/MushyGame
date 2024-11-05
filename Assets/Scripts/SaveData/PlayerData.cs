[System.Serializable] // Mark this class as serializable
public class PlayerData
{
    public float[] position;
    public String scene;

    // Constructor that captures player’s position
    public PlayerData(Player player)
    {
        scene = "SceneName";

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
