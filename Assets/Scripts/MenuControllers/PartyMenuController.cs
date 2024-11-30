using UnityEngine;
using System.Collections.Generic;

public class PartyMenuController : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> slots;
    private List<PartyMenuUI> members = new List<PartyMenuUI>();
    private Party party;
    void Start()
    {
        DeactivateMembers();
        party = GameObject.FindGameObjectWithTag("Party").GetComponent<Party>();
        foreach(GameObject slot in slots) {
            members.Add(slot.GetComponent<PartyMenuUI>());
        }
    }

    void DeactivateMembers() {
        foreach(GameObject slot in slots) {
            slot.SetActive(false);
        }
    }

    public void ActivateMembers() {
        Debug.Log($"Activating {party.party.Count} members");
        for ( int i = 0; i < party.party.Count; i++) {
            members[i].SetFields(party.party[i]);
            slots[i].SetActive(true);
        }
    }
}
