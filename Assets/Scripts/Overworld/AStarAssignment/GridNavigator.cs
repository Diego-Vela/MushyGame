using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D.IK;

public class GridNavigator : MonoBehaviour
{
  #region variables
  [SerializeField] protected Vector3Int _curTarget = Vector3Int.zero;
  [SerializeField] protected List<Vector3Int> _path = new List<Vector3Int>();
  [SerializeField] protected float _waitInterval = .25f;
  protected AstarBase _solver;
  protected Camera _mainCam;
  protected Tilemap _obstacles;  
  protected float _timer = 0f;
  #endregion
  #region functions
  void Start()
  {
    _mainCam = Camera.main;
    _solver = GetComponent<AstarBase>();
    _obstacles = GameObject.FindGameObjectWithTag("Obstacles").GetComponent<Tilemap>();
  }
  // Update is called once per frame
  void Update()
  {
    //Pressing space will kick off our desired chain of interactions
    if(Input.GetKeyDown(KeyCode.Space))
    {
      UpdatePath();
    }
    if((transform.position - _obstacles.GetCellCenterWorld(_curTarget)).magnitude > .1f)
    {
      transform.position = Vector3.MoveTowards(transform.position, 
        _obstacles.GetCellCenterWorld(_curTarget), Time.deltaTime);
    }
    else
    {
      if(_path.Count == 0) return;
      _timer += Time.deltaTime;
      if(_timer > _waitInterval)
      {
        _timer = 0f;
        _curTarget = _path[_path.Count-1];
        _path.RemoveAt(_path.Count-1);
      }
    }
  }
  /// <summary>
  /// Sets the current path for the grid navigator. It will utilize the CalculatePath function
  /// implemented by an attached script that is derived from AstarBase. An example is provided to you
  /// in EricMay.cs. Your script should enable proper behavior when attached to the prefab named
  /// "GridNavigatorEmpty.prefab" in the base scene provided to you.
  /// </summary>
  /// <param name="path">The new path to be accepted by the navigator. It uses values from the back first.</param>
  /// <param name="needsReversed">For testing purposes, use true to reverse the contents passed in through path. Your submission will be evaluated with this set to false, so write your code to assume the same.</param>
  void setPath(List<Vector3Int> path, bool needsReversed = false)
  {
    _path.Clear();
    _path = new List<Vector3Int>(path);
    if(needsReversed) _path.Reverse();
  }
  public void UpdatePath()
  {
    setPath(_solver.CalculatePath(transform.position,
    _mainCam.ScreenToWorldPoint(Input.mousePosition),
    _obstacles));
  }
  #endregion
  #region testing
  [ContextMenu("Test CellAnalysis sorting")]
  void PerformTests()
  {
    List<CellAnalysis> items = new List<CellAnalysis>();
    for(int i = 0; i < 10; i++)
    {
      var cell = new CellAnalysis();
      cell.totalDist = Random.Range(0, 100);
      cell.distToStart = Random.Range(0, 100);
      cell.distToGoal = Random.Range(0, 100);
      cell.cell = new Vector3Int(Random.Range(-10,10), 
        Random.Range(-10, 10), Random.Range(-10,10));
      items.Add(cell);
      Debug.Log(items.Count.ToString() + ": " + cell);
    }
    items.Sort();
    Debug.Log("Sorted!");
    for(int i = 0; i < 10; i++)
    {
      Debug.Log(i.ToString() + ": " + items[i]);
    }
  }
  #endregion
}
