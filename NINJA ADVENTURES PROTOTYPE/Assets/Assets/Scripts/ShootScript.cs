using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour
{


    private PlayerControl playerControl;
    public Transform sword;


    public float shootingRate = 0.25f;

    public bool isEnemy = true;

    private float shootCooldown;

    void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
    public void Attack(bool isEnemy)
    {




        var shootTransform = Instantiate(sword) as Transform;


        shootTransform.position = transform.position;


        MoveScript move = shootTransform.gameObject.GetComponent<MoveScript>();
        if (move != null)
        {
            
            

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








    
   
