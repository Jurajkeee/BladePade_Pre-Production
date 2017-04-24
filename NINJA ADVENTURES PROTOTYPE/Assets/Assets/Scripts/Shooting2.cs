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
    
    
    
    

    void Update()
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
            bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
            bullet.AddComponent<Animator>();
            bullet.AddComponent<SwordScript>();
            bullet.AddComponent<EnablingColliders>();
            Vector3 targetDir = worldMousePos - transform.position;

            float angle = Vector2.Angle(targetDir, transform.right);
           
            if (angle > 90f)
            {
                
                
                bullet.GetComponent<Transform>().transform.localScale = new Vector3(-1,1,0) ;


            }
            
        }
        //place for ignoring collision

        //ignoring collision ended

    }
    void Start()
    {
        anims = GetComponent<Animator>();
        anims.SetFloat("flying", 2);
        
        
        shooted = GetComponent<SwordScript>();
    }
    

}

