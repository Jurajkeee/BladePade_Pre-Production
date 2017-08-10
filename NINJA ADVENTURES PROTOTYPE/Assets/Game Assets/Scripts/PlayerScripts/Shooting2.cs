using UnityEngine;
using System.Collections;

public class Shooting2 : MonoBehaviour
{
    public KeyCode Fire = KeyCode.F;

    public float speed;
    private float vertical;
    private float horizontal;
    public float Counter;
    private float timestamp;
    public float timeBetweenShoot = 0.3333f;


    private Animator anims;
    
    public GameObject rocket;


    public Transform weapon;
    public Transform trajectory;

   
    
    public PlayerControl playerControl;
    private Vector3 startScale;
    
    
    public SwordScript shooted;
    public ClickingArea clickingArea;



    public bool shootNow;
     
    
    public float angle1;

    void Start()
    {
        clickingArea = clickingArea.GetComponent<ClickingArea>();
        anims = GetComponent<Animator>();
        anims.SetFloat("flying", 2);



        playerControl = GetComponent<PlayerControl>();
        shooted = GetComponent<SwordScript>();

        startScale = rocket.GetComponent<Transform>().transform.localScale;



    }


    void Update()
    {
        angle1 = transform.eulerAngles.z;
        if (Time.time>=timestamp && shootNow )
        {
            
            Vector3 worldMousePos = trajectory.transform.position;
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            Vector3 targetDir = worldMousePos - transform.position;
            float angle = Vector2.Angle(targetDir, transform.right);
           
            GameObject bullet = (GameObject)Instantiate(rocket,transform.position + (Vector3)(direction * 0.5f),Quaternion.identity);
            if (angle1 > 90f && angle1 < 270f)
            {
                bullet.GetComponent<Transform>().transform.localScale = new Vector3(-1, 1, -1);
            }

            bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
            bullet.AddComponent<Animator>();
            bullet.AddComponent<SwordScript>();
            bullet.AddComponent<EnablingColliders>();                    
            
            timestamp = Time.time + timeBetweenShoot;
            shootNow = false;
            Counter++;
            print(angle1);

        }
        

        //place for ignoring collision

        //ignoring collision ended

    }
    
    

}

