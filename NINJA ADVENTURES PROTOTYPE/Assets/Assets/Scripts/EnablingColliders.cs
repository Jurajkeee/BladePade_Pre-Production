using UnityEngine;
using System.Collections;

public class EnablingColliders : MonoBehaviour
{
    private Transform childObj;
    private Transform childObjSecond;
    private Collider2D myColl;

	// Use this for initialization
	void Start ()
	{
	    childObj = transform.FindChild("Collider");
	    childObjSecond = transform.FindChild("Effectors");
        childObj.gameObject.SetActive(true);
        childObjSecond.gameObject.SetActive(false);
	    myColl = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(myColl, childObj.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(myColl, childObjSecond.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(childObj.GetComponent<Collider2D>(), myColl);
        Physics2D.IgnoreCollision(childObjSecond.GetComponent<Collider2D>(), myColl);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Side" )
        {
            
            childObjSecond.gameObject.SetActive(true);
            myColl.enabled = !myColl.enabled;

        }
    }
}
