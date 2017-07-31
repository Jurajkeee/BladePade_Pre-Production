using UnityEngine;
using System.Collections;

public class Shooting2 : MonoBehaviour
{
    public GameObject rocket;
    public float speed;
    public KeyCode Fire = KeyCode.F;
    public SwordScript shooted;
    private Animator anims;
    private float vertical;
    private float horizontal;
    public Transform weapon;
    public float Counter;
    public float timeBetweenShoot = 0.3333f;
    private float timestamp;
    public PlayerControl playerControl;
     
    
    public float angle1;




    void Update()
    {
        angle1 = transform.eulerAngles.z;
        if (Time.time>=timestamp && Input.GetKeyUp(Fire))
        {
            
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            Vector3 targetDir = worldMousePos - transform.position;
            float angle = Vector2.Angle(targetDir, transform.right);
            GameObject bullet = (GameObject)Instantiate(rocket,transform.position + (Vector3)(direction * 0.5f),Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
            bullet.AddComponent<Animator>();
            bullet.AddComponent<SwordScript>();
            bullet.AddComponent<EnablingColliders>();                    
            if (angle1 > 90f && angle1 < 270f)
            {
                bullet.GetComponent<Transform>().transform.localScale = new Vector3(-1,1,-1);
            }
            timestamp = Time.time + timeBetweenShoot;

        }
       
        //place for ignoring collision

        //ignoring collision ended

    }
    void Start()
    {
        anims = GetComponent<Animator>();
        anims.SetFloat("flying", 2);
        
        

        playerControl = GetComponent<PlayerControl>();
        shooted = GetComponent<SwordScript>();
        
        
        
       

    }
    

}

