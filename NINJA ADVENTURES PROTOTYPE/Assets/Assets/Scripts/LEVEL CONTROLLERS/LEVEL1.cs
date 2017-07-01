using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LEVEL1 : MonoBehaviour {
    public int swordCount;
    public GUIText swordCountGUI;
    public KeyCode Fire;
	// Use this for initialization
	void Start () {
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Fire))
        {
            RemoveSword();
        }
	}
    public void UpdateScore()
    {
        
            
            swordCountGUI.text = "Swords:" + swordCount;
        
    }
    public void RemoveSword()
    {
        swordCount--;
        UpdateScore();
    }
}
