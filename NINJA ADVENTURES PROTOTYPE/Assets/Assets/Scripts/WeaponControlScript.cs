using UnityEngine;
using System.Collections;

public class WeaponControlScript : MonoBehaviour {
    public KeyCode Fire = KeyCode.F;
    private ShootScript shootScript;
    private PlayerControl player;
    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerControl>();
        shootScript = GetComponent<ShootScript>();
    }
	
	// Update is called once per frame
	void Update () {
        
        
            if (Input.GetKeyDown(Fire))
            {
                shootScript.Attack(true);

            }
        
	}
}
