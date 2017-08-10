using UnityEngine;
using System.Collections;

public class WeaponDirection : MonoBehaviour {

    public bool lookAtCursor;
    public GameObject weapon;
    public GameObject player;
    public Transform trajectory;
    public ClickingArea clickingArea;
    void Start () {
	    
        player= GameObject.Find("Player");
        clickingArea = clickingArea.GetComponent<ClickingArea>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        
        weapon.GetComponent<Transform>().transform.position = player.GetComponent<Transform>().transform.position;
        if (!clickingArea.isClicked && clickingArea.isSpawned)
        {
            clickingArea.isSpawned = false;
            
            
        }
        if (clickingArea.isClicked&&trajectory!=null)
        {
            Vector3 lookPos = new Vector3(trajectory.position.x, trajectory.position.y,0);
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
