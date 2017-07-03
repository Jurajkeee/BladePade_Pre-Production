using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour
{
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
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Side"|| collision.transform.tag == "LeftSide")
        {
            
            body.gravityScale = 0;
            body.isKinematic = true;
            anims.SetFloat("flying", -2);
            

        }
       
        
    }


   
    



    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) count++;
        if (count > 5)
        
            Destroy(gameObject);
       
        

    }
}