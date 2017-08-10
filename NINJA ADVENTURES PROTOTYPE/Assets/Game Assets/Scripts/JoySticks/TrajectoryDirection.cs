using UnityEngine;
using System.Collections;

public class TrajectoryDirection : MonoBehaviour {
    public ClickingArea clickingArea;


    // Use this for initialization
    void Start()
    {

        clickingArea = clickingArea.GetComponent<ClickingArea>();


    }

    // Update is called once per frame
    void Update()
    {
        if (clickingArea.isClicked)
        {
            
            Vector3 oppPos = clickingArea.joystick.transform.localPosition * -1;
            transform.localPosition = new Vector3(oppPos.x, oppPos.y, 0);
        }
        else transform.localPosition = new Vector3(0, 0, 0);

    }
}
