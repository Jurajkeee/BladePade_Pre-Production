using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(80, 80);
	public Vector2 direction = new Vector2(0, 0);
	
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;
	
	void Update()
	{
		movement = new Vector2(
			speed.x * direction.x*1,
			speed.y * direction.y*1);
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