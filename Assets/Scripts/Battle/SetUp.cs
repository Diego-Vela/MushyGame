using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetUp : MonoBehaviour
{
    // Variables
    public List<Stats> party = new List<Stats>();

    // References
    public GameObject position1;
    public GameObject position2;

    public BattleEntity position1Entity;
    public BattleEntity position2Entity;

    public GameObject bossPosition;
    public BattleEntity bossEntity;
    
    private void Start() 
    {        
        SetUpComponents();
        Reset();
        SetUpBoss();
        SetUpParty();
    }

    public void SetUpComponents()
    {
        position1Entity = position1.GetComponent<BattleEntity>();
        position2Entity = position2.GetComponent<BattleEntity>();
        bossEntity = bossPosition.GetComponent<BattleEntity>();
    }

    private void Reset()
    {
        position1.SetActive(false);
        position2.SetActive(false);
    }

    private void SetUpBoss()
    {
        bossEntity.CreateEntity(EnemyInfo.Instance.enemyEntity);
    }

    private void GetPartyInfo()
    {
        foreach (CharacterStats character in Party.Instance.party)
        {
            party.Add(character);
        }
    }
    
    private void SetUpParty()
    {
        GetPartyInfo();

        switch(party.Count)
        {
            case 1:
                OneParty();
                break;
            case 2:
                TwoParty();
                break;
            default:
                Debug.Log("Something went wrong");
                break;
        }
    }

    private void OneParty() 
    {
        position1Entity.CreateEntity(party[0]);
        position1.SetActive(true);
    }

    private void TwoParty() 
    {
        position1Entity.CreateEntity(party[0]);
        position1.SetActive(true);

        position2Entity.CreateEntity(party[1]);
        position2.SetActive(true);

    }
}