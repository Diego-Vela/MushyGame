using UnityEngine;
using System.IO;

public static class SaveSystem
{   
    #region save-file-path
    private static string saveFilePath = Path.Combine(Application.persistentDataPath, "MushGameDemo.json");
    private static string settingsFilePath = Path.Combine(Application.persistentDataPath, "MushGameDemoSettings.json");
    #endregion

    #region public-save-system-methods
    // Function that saves the player data
    public static void Save(Player player, GameState gamestate, Party party, string scene)
    {
        // Create a new SaveData object with the current game data
        SaveData data = new SaveData(player, gamestate, party, scene);

        // Convert the data to JSON format
        string jsonData = JsonUtility.ToJson(data, true);

        // Write the JSON to the file
        File.WriteAllText(saveFilePath, jsonData);
        Debug.Log("Game saved to " + saveFilePath);
    }

    // Function that takes the data in savedData and sets it to the other parameters
    public static SaveData Load()
    {   
        string json = File.ReadAllText(saveFilePath);
        SaveData loadedData = JsonUtility.FromJson<SaveData>(json);
        Debug.Log("Game loaded from " + saveFilePath);

        return loadedData;
    }

    // Function that checks if SaveData exists
    public static bool HasSavedData()
    {
        return File.Exists(saveFilePath);
    }

    // Function that deletes SaveData
    public static void DeleteSaveData()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("Save file deleted.");
        }
        else
        {
            Debug.Log("No save file to delete.");
        }
    }


    /*public static void SaveSettings(float volume, float brightness) {
        SettingsSave settingsData = new SettingsSave(volume, brightness);

        string jsonData = JsonUtility.ToJson(settingsData, true);

        saveFilePath.WriteAllText(SettingsFilePath, jsonData);
        Debug.Log("Settings Being Saved");
    }
    public static SettingsSave Load() {

    }*/

    #endregion
}
