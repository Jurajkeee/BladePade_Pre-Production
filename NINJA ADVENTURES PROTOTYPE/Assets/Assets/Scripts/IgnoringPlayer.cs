using UnityEngine;
using System.Collections;

public class IgnoringPlayer : MonoBehaviour
{
    private Collider2D mycollider;
    // Use this for initialization
    void Start ()
    {
        //find child collider

        mycollider = GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Side" || collision.transform.tag == "LeftSide")
        {
            mycollider.isTrigger = !mycollider.isTrigger;


        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Side" || collision.transform.tag == "LeftSide")
        {
            mycollider.isTrigger = !mycollider.isTrigger;
        }
    }
}
