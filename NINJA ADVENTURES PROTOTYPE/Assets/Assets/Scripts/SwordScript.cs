using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {
    private Animator anims;
    private float vertical;
    private float horizontal;
    private Rigidbody2D body;
    public float bulletspeed = 800f;
    private Rigidbody2D mySword;
    public KeyCode Fire = KeyCode.F;
    // Use this for initialization
    void Start () {
        anims = GetComponent<Animator>();
        anims.SetFloat("flying", 2);
        mySword = GetComponent<Rigidbody2D>();
        body = GetComponent<Rigidbody2D>();
        GameObject Sword = GameObject.Find("Sword");
        PlayerControl playerControl = Sword.GetComponent<PlayerControl>();
    }
    void OnCollisionEnter2D(Collision2D  collision) {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Side")
        {
            body.gravityScale = 0;
            body.isKinematic = true;
            anims.SetFloat("flying", -2);
            float angle = 0;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
       
           
        
    }
	
	// Update is called once per frame
	void Update () {
        
	
	}
}
