using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CompanionInteraction : NPCInteraction
{
    private Party party;
    private PartyCreator partyCreator;

    public StateManager stateManager;
    
    void Start()
    {
        party = GameObject.FindGameObjectWithTag("Party").GetComponent<Party>();
        partyCreator = GameObject.FindGameObjectWithTag("PartyCreator").GetComponent<PartyCreator>();

        characterName = transform.parent.gameObject.name;
        isCompanion = true;
    }
    
    public override void deactivateNPC()
    {        
        // Deactivate NPC
        npcObject.SetActive(false);
        stateManager.Despawn(characterName);
        // Add to party
        AddToParty();
    }

    private void AddToParty()
    {
        partyCreator.AddCharacterByName(characterName);
    }

}
