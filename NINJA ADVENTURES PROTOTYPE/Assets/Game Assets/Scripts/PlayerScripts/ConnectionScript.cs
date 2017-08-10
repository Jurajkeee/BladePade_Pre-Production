using UnityEngine;
using System.Collections;

public class ConnectionScript : MonoBehaviour {
    
    public Transform toConnect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = toConnect.transform.position;
	}
}
