using UnityEngine;
using System.Collections;

public class PuzzleWall : MonoBehaviour {
    public Transform wall;
    public GameObject buttonUP_GO;
    public ButtonUP buttonUP;
    public GameObject buttunDown_GO;
    public ButtonDown buttonDown;
    public float speed;
    public float maxY;
    public float minY;
    
	// Use this for initialization
	void Start () {
        buttonUP = buttonUP_GO.GetComponent<ButtonUP>();
        buttonDown = buttunDown_GO.GetComponent<ButtonDown>();
        wall = wall.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (buttonUP.isTrue == true && wall.transform.position.y < maxY)
        {
            wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + (Time.timeScale * speed), wall.transform.position.z);
        }
        if(buttonDown.isTrue == true && wall.transform.position.y > minY)
        {
            wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y - (Time.timeScale * speed), wall.transform.position.z);
        }
	}

}
