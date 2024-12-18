using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyCreator : MonoBehaviour
{
    public static PartyCreator Instance;
    public Texture2D gunther;
    public Texture2D player;
    public Texture2D charlotte;
    public Texture2D daisy;

    private Party party;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Killing myself");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        party = GameObject.FindWithTag("Party").GetComponent<Party>();
    }

    public void AddCharacterByName(string name)
    {
        switch(name)
        {
            case "Gunther":
                party.AddPartyMember(new GuntherStats(gunther));
                break;
            case "Charlotte":
                party.AddPartyMember(new CharlotteStats(charlotte));
                break;
            case "Daisy":
                party.AddPartyMember(new DaisyStats(daisy));
                break;
            default:
                party.AddPartyMember(new CharacterStats(player));
                break;
        }
    }

    public void LoadCharacterData(CharacterSaveData character) {
        switch(character.characterName) {
            case "Gunther":
                party.AddPartyMember(new CharacterStats(gunther, character));
                break;
            case "Charlotte":
                party.AddPartyMember(new CharacterStats(charlotte, character));
                break;
            case "Daisy":
                party.AddPartyMember(new CharacterStats(daisy, character));
                break;
            default:
                party.AddPartyMember(new CharacterStats(player, character));
                break;
        }
    }
}
