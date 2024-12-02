using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Party : MonoBehaviour
{   
    // Singleton instance
    public static Party Instance;

    // List of party
    public List<CharacterStats> party = new List<CharacterStats>();

    private void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this instance across scenes
        }
        else
        {
            Debug.Log($"Destroying instance with {party.Count} party members");
            Destroy(gameObject);  // Ensure only one instance exists
        }
    }

    public void AddPartyMember(CharacterStats member)
    {
        party.Add(member);
        Debug.Log($"Added {member.characterName} to party");
        
        // Debug Function
        //PrintParty();
    }

    public void PrintParty()
    {
        int count = 0;
        foreach (CharacterStats character in party)
        {
            Debug.Log($"Party member {count}: {character.characterName}\n");
            count++;
        }
    }

    public void DeleteParty()
    {
        party.Clear();
        Debug.Log("Party was cleared");
    }
}
