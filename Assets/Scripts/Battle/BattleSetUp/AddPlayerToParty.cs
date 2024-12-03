using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerToParty: MonoBehaviour
{
    public Party party;
    public Texture2D image;
    
    void Start()
    {
        AddToParty("Protagonist");
    }

    private void AddToParty(string name)
    {
        CharacterStats member = new CharacterStats(image);
        member.PrintStats();

        party.AddPartyMember(member);
    }

}
