using UnityEngine;
using System.Collections;

public class WeaponDirection : MonoBehaviour {

    public bool lookAtCursor;
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (lookAtCursor == false)
        {

            float angle = 0;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (lookAtCursor)
        {
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
