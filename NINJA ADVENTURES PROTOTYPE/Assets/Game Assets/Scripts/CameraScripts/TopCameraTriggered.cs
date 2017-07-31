using UnityEngine;
using System.Collections;

public class TopCameraTriggered : MonoBehaviour {
    public bool isTriggeringWithIT;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        
            isTriggeringWithIT=true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")

            isTriggeringWithIT = false;
    }
}
