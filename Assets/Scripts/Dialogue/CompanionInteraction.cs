using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CompanionInteraction : NPCInteraction
{
    private Party party;
    
    void Start()
    {
        party = GameObject.FindGameObjectWithTag("Party").GetComponent<Party>();
        isCompanion = true;
    }
    
    public override void deactivateNPC()
    {        
        // Deactivate NPC
        npcObject.SetActive(false);
        // Debug Statement
        Debug.Log("Parent NPC has been deactivated.");
        // Add to party
        AddToParty(transform.parent.gameObject.name);
    }

    private void AddToParty(string name)
    {
        CharacterStats member = new CharacterStats(name, image);
        member.PrintStats();

        party.AddPartyMember(member);
    }

}
