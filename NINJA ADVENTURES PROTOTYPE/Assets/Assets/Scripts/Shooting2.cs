using UnityEngine;
using System.Collections;

public class Shooting2 : MonoBehaviour {
    public GameObject rocket;
    public float speed;
    public KeyCode Fire = KeyCode.F;
    public SwordScript shooted;
    private Animator anims;
    private float vertical;
    private float horizontal;
    private Rigidbody2D body;
    private int collisionCount = 0;


    void FixedUpdate()
    {
        if (Input.GetKeyDown(Fire))
        {

            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            GameObject bullet = (GameObject)Instantiate(
                                    rocket,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);



            bullet.GetComponent<Rigidbody2D>().velocity = direction * speed
                ;
            bullet.AddComponent<Animator>();
            bullet.AddComponent<SwordScript>();
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bullet.GetComponent<Collider>());
        }
        
    }
   

    void Start () {

        anims = GetComponent<Animator>();
        anims.SetFloat("flying", 2);

        body = GetComponent<Rigidbody2D>();
        shooted = GetComponent<SwordScript>();
        
        
    }
    


    

}
