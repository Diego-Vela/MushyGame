using UnityEngine;
using System.Collections.Generic;

public class PanelsController : MonoBehaviour
{
    public List<GameObject> panels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach (GameObject panel in panels) {
            panel.SetActive(true);
        }
    }
}
