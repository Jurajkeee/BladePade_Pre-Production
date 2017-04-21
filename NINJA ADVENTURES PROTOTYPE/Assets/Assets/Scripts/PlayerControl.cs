using UnityEngine;
using System.Collections;



public class PlayerControl : MonoBehaviour
{



    private Animator anim;
    public float speed = 500;
    public float jumpForce = 40;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode addJumpForceButton = KeyCode.Space;
    public bool isFacingRight = true;
    private Vector3 direction;
    private float vertical;
    private float horizontal;
    private Rigidbody2D body;
    private float rotationY;
    private bool jump;
    public KeyCode Fire = KeyCode.F;
    public bool lookAtCursor;
    
  
    
    


    private void Start()

    {
        
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        body.fixedAngle = true;
       
    }
   
        private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "bullet")
        {

            body.drag = 10;
            jump = true;
        }
        if (collision.transform.tag == "Side"|| collision.transform.tag == "LeftSide")
        {
            body.drag = 0;
            jump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "bullet")
        {

            body.drag = 0;
            jump = false;
        }
        if (collision.transform.tag == "Side" || collision.transform.tag == "LeftSide")
        {
            body.drag = 0;
            jump = false;
        }
    }
    private void FixedUpdate()
    {
        body.AddForce(direction * body.mass * speed);
        if (Mathf.Abs(body.velocity.x) > speed / 100f)
        {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);

        }


    }

   
    private void Update()
    {
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


        //left move needs to add anim Running
        if (Input.GetKey(leftButton))
        {
            horizontal = -1;



        }
        //right move needs to add anim Running
        else if (Input.GetKey(rightButton))
        {
            horizontal = 1;


        }
        else
            horizontal = 0;
        //Jumping needs to add anim Jumping
        if (Input.GetKey(addJumpForceButton) && jump)
        {
            body.velocity = new Vector2(0, jumpForce);

        }




        direction = new Vector2(horizontal, 0);

        //Facing (Povorot) loop for it ,needed, dont touch it
        


        //ANIMATION SCRIPTS


        if (Input.GetKey(rightButton) | Input.GetKey(leftButton) && vertical == 0)
        {
            anim.SetFloat("Forward", 1);
            anim.SetFloat("Standing", 2);
            anim.SetFloat("Jumping", 0);
            anim.SetFloat("Shooting", 0);
            lookAtCursor = false;
           

        }
        if (horizontal == 0 && vertical == 0)
        {
            anim.SetFloat("Jumping", 0);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", -1);
            anim.SetFloat("Shooting", 0);
            lookAtCursor = false;
            
        }
        if (Input.GetKey(addJumpForceButton))
        {
            anim.SetFloat("Jumping", 2);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", 2);
            anim.SetFloat("Shooting", 0);
            lookAtCursor = false;
            
        }
        if (Input.GetKey(addJumpForceButton) && (Input.GetKeyDown(rightButton) | Input.GetKeyDown(leftButton)) && vertical == 0)
        {
           
            anim.SetFloat("Jumping", 2);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", 0);
            anim.SetFloat("Shooting", 0);
            lookAtCursor = false;
        }
        if (Input.GetKey(Fire)) {
           

            anim.SetFloat("flying", 2);
            anim.SetFloat("Jumping", 0);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", 0);
            anim.SetFloat("Shooting", 1);
            lookAtCursor = true;
        }
        
        
    }

    
}
	



        
    

    


