using UnityEngine;
using System.Collections;



public class PlayerControl : MonoBehaviour
{
    public Vector3 startingScale;


    public Animator anim;
    public float speed = 500;
    public float jumpForce = 40;
    
   
    
    
    
    private Vector3 direction;
    private float vertical;
    private float horizontal;
    private Rigidbody2D body;
    private float rotationY;
    private bool jump;
    public KeyCode Fire = KeyCode.F;
    public bool lookAtCursor;
    public FliperScript fliperScript;
    
    //Slower
    public float slowerSpeed;
    public float slowerjumpForce;
    public ClickingArea clickingArea;
    public Transform trajectory;
    public Shooting2 shooting2;
    //
    public bool onMovingPlatform;
    public bool inSlower;
   [SerializeField] float startSpeed;
   [SerializeField] float startJumpForce;

    public MovingJoystick movingjoystick;
    public JumoingButton jumpingButton;
    


    private void Start()
    {
        shooting2 = shooting2.GetComponent<Shooting2>();
         clickingArea = clickingArea.GetComponent<ClickingArea>();
        startSpeed = speed;
        startJumpForce = jumpForce;
        startingScale = transform.localScale;
        fliperScript = GameObject.Find("Player").GetComponent<FliperScript>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        body.fixedAngle = true;

        movingjoystick = movingjoystick.GetComponent<MovingJoystick>() ;
        jumpingButton = jumpingButton.GetComponent<JumoingButton>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground" )
        {            
            body.drag = 10;
            jump = true;
            
        }
        if (collision.transform.tag != "Ground")
        {
            body.drag = 0;
            jump = false;
           
        }
        


    }
    

    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" )
        {
            body.drag = 10;
            jump = true;
            
        }
        if (collision.transform.tag != "Ground")
        {
            body.drag = 0;            
            jump = false;
           
        }
       


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" )
        {
            body.drag = 0;
            jump = false;
            
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Slower")
        {
           inSlower = true;
        }
        if (collision.transform.name == "Sword (1)(Clone)" || collision.transform.name == "MovingPlatform")
        {
            if (collision.transform.name == "Movingplatform")
                transform.localScale = new Vector3(0.4323924F, 0.4323924F, 0.4323924F);
            transform.parent = collision.transform;
            onMovingPlatform = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Slower")
        {
            inSlower = false;

        }
        if (collision.transform.name == "Sword (1)(Clone)" || collision.transform.name == "MovingPlatform")
        {
            if (collision.transform.name == "Movingplatform")
                transform.localScale = startingScale;
            transform.parent = null;
            onMovingPlatform = false;

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
       
        if(!inSlower)
        {
            speed = startSpeed;
            jumpForce = startJumpForce;
        }else
        {
            speed = slowerSpeed;
            jumpForce = slowerjumpForce;
        }

        if ( transform.localScale.y != startingScale.y || transform.localScale.z != startingScale.z  )
        {
            if (!onMovingPlatform)
                transform.localScale = startingScale;
            if(onMovingPlatform)
                transform.localScale = new Vector3(0.4323924F, 0.4323924F, 0.4323924F);
        }

        if (lookAtCursor == false)
        {

            float angle = 0;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (lookAtCursor)
        {
            Vector3 lookPos = new Vector3(trajectory.position.x, trajectory.position.y, 0);
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


        //left move needs to add anim Running
        if (movingjoystick.goLeft)
        {
            horizontal = -1;



        }
        //right move needs to add anim Running
        else if (movingjoystick.goRight)
        {
            horizontal = 1;


        }
        else
            horizontal = 0;
        //Jumping needs to add anim Jumping
        if (jumpingButton.jump && jump)
        {
            body.velocity = new Vector2(0, jumpForce);

        }




        direction = new Vector2(horizontal, 0);

        //Facing (Povorot) loop for it ,needed, dont touch it
        


        //ANIMATION SCRIPTS


        if (movingjoystick.goRight | movingjoystick.goLeft && vertical == 0 && !clickingArea.isClicked)
        {
            anim.SetFloat("Forward", 1);
            anim.SetFloat("Standing", 2);
            anim.SetFloat("Jumping", 0);
            anim.SetFloat("Shooting", 0);
            anim.SetFloat("Real_shooting", 1);
            lookAtCursor = false;
           

        }
        if (horizontal == 0 && vertical == 0 && !clickingArea.isClicked)
        {
            anim.SetFloat("Jumping", 0);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", -1);
            anim.SetFloat("Shooting", 0);
            anim.SetFloat("Real_shooting", 1);
            lookAtCursor = false;
            
        }
        if (jumpingButton.jump && !clickingArea.isClicked)
        {
            anim.SetFloat("Jumping", 2);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", 2);
            anim.SetFloat("Shooting", 0);
            anim.SetFloat("Real_shooting", 1);
            lookAtCursor = false;
            
        }
        if (jumpingButton.jump && movingjoystick.goRight | movingjoystick.goLeft && vertical == 0 && !clickingArea.isClicked)
        {
           
            anim.SetFloat("Jumping", 2);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", 0);
            anim.SetFloat("Shooting", 0);
            anim.SetFloat("Real_shooting", 1);
            lookAtCursor = false;
        }
        if (clickingArea.isClicked ) {
           

            
            anim.SetFloat("Jumping", 0);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", 0);
            anim.SetFloat("Shooting", 1);
            anim.SetFloat("Real_shooting", 0);
            lookAtCursor = true;
         

        }
        if (shooting2.shootNow)
        {
            anim.SetFloat("Jumping", 0);
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Standing", 0);
            anim.SetFloat("Shooting", 0);
            anim.SetFloat("Real_shooting", 1);

        }
        





    }

    
}
	



        
    

    


