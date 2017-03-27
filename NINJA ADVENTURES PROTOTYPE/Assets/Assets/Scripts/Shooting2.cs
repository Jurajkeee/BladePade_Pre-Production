using UnityEngine;
using System.Collections;

public class Shooting2 : MonoBehaviour {
    public GameObject rocket;
    public float speed;
    public KeyCode Fire = KeyCode.F;
   
    // Use this for initialization
    void Start () {
        
       
        
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	if (Input.GetKeyDown(Fire))
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();

            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate(
                                    rocket,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);

            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * speed
                ;
        }
	}
}
