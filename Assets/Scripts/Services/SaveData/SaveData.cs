using System.IO;

[System.Serializable] // Mark this class as serializable
public class SaveData
{
    // Player Data
    public float[] position;
    // GameState Data
    public bool charlotte;
    public bool gunther;
    public bool waterDefeated;
    public bool earthDefeated;
    public bool demonDefeated;
    // Party Data
    public string[] party;
    // cene Data
    public string scene;

    // Capture player position, game state, party details, and scene name
    public SaveData(Player player, GameState gamestate, Party party, string scene)
    {
        SavePlayerData(player);
        SaveGameStateData(gamestate);
        SavePartyData(party);
        SaveScene(scene);
    }

    private void SavePlayerData(Player player)
    {
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }

    private void SaveGameStateData(GameState gamestate)
    {
        // Hometown state
        this.charlotte = gamestate.charlotte;
        this.gunther = gamestate.gunther;

        // Forest state
        this.waterDefeated = gamestate.waterDefeated;
        this.earthDefeated = gamestate.earthDefeated;
        this.demonDefeated = gamestate.demonDefeated;
    }

    private void SavePartyData(Party party)
    {
        this.party = new string[party.party.Count]; 

        for (int i = 0; i < party.party.Count; i++)
        {
            this.party[i] = party.party[i].characterName;
        }
    }

    private void SaveScene(string scene)
    {
        this.scene = scene;
    }
}
