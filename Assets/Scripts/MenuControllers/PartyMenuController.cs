using UnityEngine;
using System.Collections.Generic;

public class PartyMenuController : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> members;
    private Party party;
    void Start()
    {
        DeactivateMembers();
        party = GameObject.FindGameObjectWithTag("Party").GetComponent<Party>();
        ActivateMembers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeactivateMembers() {
        foreach(GameObject member in members) {
            member.SetActive(false);
        }
    }

    void ActivateMembers() {
        for ( int i = 0; i < party.party.Count; i++) {
            members[i].SetActive(true);
            SetName(members[i],party.party[i]);
            SetLevel(members[i],party.party[i]);
            SetHp(members[i],party.party[i]);
            SetExp(members[i],party.party[i]);
        }
    }

    private void SetName(GameObject member, CharacterStats character) {

    }
    
    private void SetLevel(GameObject member, CharacterStats character) {
        
    }

    private void SetHp(GameObject member, CharacterStats character) {
        
    }

    private void SetExp(GameObject member, CharacterStats character) {
        
    }

}
