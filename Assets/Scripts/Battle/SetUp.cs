using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetUp : MonoBehaviour
{
    // References
    public List<GameObject> positions;

    public List<BattleEntity> positionsEntity;

    public GameObject bossPosition;
    public BattleEntity bossEntity;
    
    private void Start() 
    {        
        Reset();
        SetUpBoss();
        SetUpParty();
    }

    private void Reset()
    {
        foreach (GameObject position in positions)
        {
            position.SetActive(false);
        }
    }

    private void SetUpBoss()
    {
        bossEntity.CreateEntity(EnemyInfo.Instance.enemyEntity);
    }
    
    private void SetUpParty()
    {
        int positionIdx = 0;
        foreach (Stats character in Party.Instance.party)
        {
            positionsEntity[positionIdx].CreateEntity(character);
            positions[positionIdx].SetActive(true);
            positionIdx++;
        }
    }
}