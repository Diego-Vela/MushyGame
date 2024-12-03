using System.IO;
using System.Collections.Generic;
//test
[System.Serializable] // Mark this class as serializable
public class SaveData
{
    // Player Data
    public float[] position;
    // GameState Data
    public bool charlotte;
    public bool gunther;
    public bool daisy;
    public bool waterDefeated;
    public bool earthDefeated;
    public bool demonDefeated;
    // Party Data
    public List<CharacterSaveData> party;
    // cene Data
    public string scene;

    // Capture player position, game state, party details, and scene name
    public SaveData(Player player, GameState gamestate, Party party, string scene)
    {
        SavePlayerPositionData(player);
        SaveGameStateData(gamestate);
        SavePartyData(party);
        SaveSceneData(scene);
    }

    private void SavePlayerPositionData(Player player)
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
        this.daisy = gamestate.daisy;

        // Forest state
        this.waterDefeated = gamestate.waterDefeated;
        this.earthDefeated = gamestate.earthDefeated;
        this.demonDefeated = gamestate.demonDefeated;
    }

    private void SavePartyData(Party party)
    {
        this.party = new List<CharacterSaveData>();

        foreach (CharacterStats member in party.party) {
            this.party.Add(SaveCharacterData(member));
        }
    }

    private void SaveSceneData(string scene)
    {
        this.scene = scene;
    }

    private CharacterSaveData SaveCharacterData(CharacterStats character) {
        return new CharacterSaveData
        {
            characterName = character.characterName,
            characterClass = character.characterClass,
            hp = character.hp,
            currentHp = character.currentHp,
            attack = character.attack,
            dexterity = character.dexterity,
            intelligence = character.intelligence,
            speed = character.speed,
            level = character.level,
            expMultiplier = character.expMultiplier,
            expToNextLevel = character.expToNextLevel,
            currentExp = character.currentExp,
            friend = character.friend
        };
    }

    
}
