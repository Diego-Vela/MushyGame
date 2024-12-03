using UnityEngine;
using UnityEngine.UI;

public class EnemyCreator : MonoBehaviour
{
    public static EnemyCreator Instance;
    public EnemyInfo enemyInfo;
    public BattleResults battleResults;

    #region persistence
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this instance across scenes
        }
        else
        {
            Destroy(gameObject);  // Ensure only one instance exists
        }
    }
    #endregion

    #region createEnemy
    public void CreateEnemy(string enemyName, Texture2D image, string sceneName)
    {
        Debug.Log($"Creating {enemyName} from {sceneName}.");
        switch(sceneName)
        {
            case "ForestDungeon":
                CreateForestEnemy(enemyName, image);
                break;
            //Add more dungeons as needed
            default:
                Debug.LogWarning($"Major failure creating {enemyName}");
                break;
        }
    }
    #endregion
    
    #region forestDungeon
    void CreateForestEnemy(string enemyName, Texture2D image)
    {
        enemyInfo.enemyEntity = null; // Let the enemyEntity be garbage collected :)

        switch(enemyName)
        {
            case "WaterSlime":
                enemyInfo.enemyEntity = new WaterSlime(image);
                battleResults.enemyName = enemyName;
                Debug.Log("Successful Creation");
                break;
            case "EarthSlime":
                enemyInfo.enemyEntity = new EarthSlime(image);
                battleResults.enemyName = enemyName;
                Debug.Log("Successful Creation");
                break; 
            case "DemonSlime":
                enemyInfo.enemyEntity = new DemonSlime(image);
                battleResults.enemyName = enemyName;
                Debug.Log("Successful Creation");
                break;       
            default:
                Debug.LogWarning($"Major failure creating {enemyName}");
                break;
                
        }

    }
    #endregion
}