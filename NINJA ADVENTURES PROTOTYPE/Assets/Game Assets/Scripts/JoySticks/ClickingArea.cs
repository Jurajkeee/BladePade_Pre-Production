using UnityEngine;
using System.Collections;

public class ClickingArea : MonoBehaviour {
    public bool isClicked;
    public bool actionIsDone;
    public bool isUp;
    public bool isSpawned;
    public Transform player;
    public Transform baseForJoystick;
    public Transform joystick;
    public GameObject joystickGO;
    public GameObject trajectoryGO;
    public Shooting2 shooting2;
    // Use this for initialization
    void Start()
    {
        shooting2 = shooting2.GetComponent<Shooting2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            joystickGO.SetActive(true);
            trajectoryGO.SetActive(true);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (actionIsDone == false)
            {
                baseForJoystick.transform.position = mousePos;
                joystick.transform.parent = baseForJoystick.transform;
                joystick.transform.localPosition = new Vector3(0, 0, -7);
                actionIsDone = true;
            }
            joystick.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            isSpawned = true;


        }
        else
        {
            joystickGO.SetActive(false);
            trajectoryGO.SetActive(false);
            joystick.transform.parent = player.transform;
        }
    }
    private void OnMouseDown()
    {
        isClicked = true;
    }
    private void OnMouseUp()
    {
        isClicked = false;
        actionIsDone = false;
        shooting2.shootNow = true;

        
    }
}

