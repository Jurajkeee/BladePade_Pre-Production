using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(80, 80);
	public Vector2 direction = new Vector2(0, 0);
   
    private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;
    private PlayerControl player;
	void Start()
    {
         
    player = GetComponent<PlayerControl>();
    }
    void Update()
    {

        if (player.isFacingRight == true)
        {
            Debug.Log("RightShoot");
            movement = new Vector2(
            speed.x * direction.x * 1,
            speed.y * direction.y * 1);
        }
        if (player.isFacingRight == false)
        {
            movement = new Vector2(
            speed.x * direction.x * 1,
            speed.y * direction.y * 1);
            Debug.Log("LeftShoot");
        }

        
       
    }
	void OnCollisionEnter2D(Collision2D  collision) {
		if (collision.transform.tag == "Ground" || collision.transform.tag == "Side") {
			speed = new Vector2(0,0);

		}

	}
   

    void FixedUpdate()
	{
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();
		

		rigidbodyComponent.velocity = movement;
	}
}