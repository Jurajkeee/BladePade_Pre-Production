using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour {
    public bool isFinished;
	// Use this for initialization
	void Start () {
        isFinished = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFinished = true;
    }
}
