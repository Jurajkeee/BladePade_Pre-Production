using UnityEngine;
using System.Collections;

public class SlowerScript : MonoBehaviour {
    [SerializeField] private PlayerControl playerControlScript;
    public float slowerSpeed;
    public float slowerJump;
	// Use this for initialization
	void Start () {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Player")
        {
            playerControlScript.slowerSpeed = slowerSpeed;
            playerControlScript.slowerjumpForce = slowerJump;
        }
    }
}
