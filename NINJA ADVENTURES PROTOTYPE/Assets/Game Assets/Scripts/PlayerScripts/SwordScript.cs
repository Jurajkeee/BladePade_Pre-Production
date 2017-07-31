using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour
{
   
    //
    private Animator anims;
    private float vertical;
    private float horizontal;
    public Rigidbody2D body;
    public Shooting2 shooting;
    public int count = 1;
   
    
    
    public KeyCode Fire = KeyCode.F;
    // Use this for initialization
    void Start()
    {
          
            shooting = GetComponent<Shooting2>();
            anims = GetComponent<Animator>();
            anims.SetFloat("flying", 2);

            body = GetComponent<Rigidbody2D>();

        
        
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) count++;
        if (count > 5)

            Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Side"|| collision.transform.tag == "LeftSide")
        {
            
            body.gravityScale = 0;
            body.isKinematic = true;
            anims.SetFloat("flying", -2);
            

        }
           
        
    }
    private void  OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "FallingWall" || other.gameObject.name == "MovingPlatform")
        {
            transform.parent = other.transform;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "FallingWall" || collision.gameObject.name == "MovingPlatform")
        {
            transform.parent = null; 

        }
    }








}