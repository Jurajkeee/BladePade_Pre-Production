using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour
{


    private PlayerControl playerControl;
    public Transform sword;
    

    public float shootingRate = 0.25f;

    public bool isEnemy = true;

    private float shootCooldown;
    private MoveScript move;

    public float fireRate = 0.5f;
    private float nextFire = 1f;
    void Start()
    {
        
        playerControl = GetComponent<PlayerControl>();
       
        move = GetComponent<MoveScript>();
    }

    void Update()
    {
        
        if (nextFire > 1)
        {
            nextFire -= Time.deltaTime;
        }
        
    }
    public void Attack(bool isEnemy)
    {
       
            if (CanAttack && Time.time>nextFire)
            {

            nextFire = Time.time + fireRate;
            var shootTransform = Instantiate(sword) as Transform;


                shootTransform.position = transform.position;


                MoveScript move = shootTransform.gameObject.GetComponent<MoveScript>();
               



                    move.direction = this.transform.right;


               
            }
        
    }


    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
            
        }
    }
}








    
   
