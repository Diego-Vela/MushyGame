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
                party.AddPartyMember(new GuntherStats(name, gunther));
                break;
            case "Charlotte":
                party.AddPartyMember(new CharlotteStats(name, charlotte));
                break;
            case "Daisy":
                party.AddPartyMember(new DaisyStats(name, daisy));
                break;
            default:
                party.AddPartyMember(new CharacterStats("Protagonist", player));
                break;
        }
    }
}
