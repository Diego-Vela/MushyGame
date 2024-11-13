using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyCreator : MonoBehaviour
{
    public Texture2D gunther;
    public Texture2D player;
    public Texture2D charlotte;

    private Party party;

    void Start()
    {
        party = GameObject.FindWithTag("Party").GetComponent<Party>();
    }

    public void AddCharacterByName(string name)
    {
        switch(name)
        {
            case "Gunther":
                party.AddPartyMember(new CharacterStats(name, gunther));
                break;
            case "Charlotte":
                party.AddPartyMember(new CharacterStats(name, charlotte));
                break;
            default:
                party.AddPartyMember(new CharacterStats("Protagonist", player));
                break;
        }
    }
}
