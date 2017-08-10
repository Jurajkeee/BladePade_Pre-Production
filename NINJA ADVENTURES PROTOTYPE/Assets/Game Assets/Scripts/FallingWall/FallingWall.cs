using UnityEngine;
using System.Collections;

public class FallingWall : MonoBehaviour {
    

    [Range(0, 30)] public float speedOfFalling;
    [Range(0,50)]public float fallingFrequency;
    public float timerFallingWall;
    
    //Debug
    
	// Use this for initialization
	void Start () {
        
        InvokeRepeating("FallingOfTheWall", 0, fallingFrequency);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, transform.position.y - (1*0.1F), transform.position.z);
        timerFallingWall += Time.deltaTime;
    }
    void FallingOfTheWall()
    {
        timerFallingWall = 0;
        
        transform.position = new Vector3(transform.position.x, transform.position.y - speedOfFalling, transform.position.z);
       
    }
    
}
