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
        InitializeSlots();
        DeactivateMembers();
        party = GameObject.FindGameObjectWithTag("Party").GetComponent<Party>();
    }

    void DeactivateMembers() {
        foreach(GameObject slot in slots) {
            slot.SetActive(false);
        }
    }

    void InitializeSlots() {
        foreach(GameObject slot in slots) {
            slot.SetActive(true);
            slot.GetComponent<PartyMenuUI>().Initialize();
            members.Add(slot.GetComponent<PartyMenuUI>());
        }
    }

    public void ActivateMembers() {
        for ( int i = 0; i < party.party.Count; i++) {
            slots[i].SetActive(true);
            members[i].SetFields(party.party[i]);
        }
    }
}
