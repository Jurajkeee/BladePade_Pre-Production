using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(80, 80);
	
   
    private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;
    private PlayerControl player;
    public Vector3 direction;
    
	void Start()
    {
         
    player = GetComponent<PlayerControl>();
    }
    void Update()
    {

        Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        direction = direction - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 speed = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        speed = speed - transform.position;

        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();


        rigidbodyComponent.velocity = movement;
        if (player.isFacingRight)
            Debug.Log("RightShoot");
        movement = new Vector2(
        speed.x * direction.x * 1,
        speed.y * direction.y * 1);
        if (player.isFacingRight == false)
        {
            Debug.Log("LeftShoot");
            movement = new Vector2(
            speed.x * direction.x * -1,
            speed.y * direction.y * 1);
        }

    }
	void OnCollisionEnter2D(Collision2D  collision) {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Side")
        {
            speed = new Vector2(0, 0);

        }

    }
   

    void FixedUpdate()
	{
       
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

       
        rigidbodyComponent.velocity = movement;
    }
}