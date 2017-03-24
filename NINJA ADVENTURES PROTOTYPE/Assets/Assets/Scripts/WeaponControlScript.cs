using UnityEngine;
using System.Collections;

public class WeaponControlScript : MonoBehaviour {
    public KeyCode Fire = KeyCode.F;
    private ShootScript shootScript;
    // Use this for initialization
    void Start () {
        shootScript = GetComponent<ShootScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(Fire)) {
            shootScript.Attack(true);
        }
	}
}
