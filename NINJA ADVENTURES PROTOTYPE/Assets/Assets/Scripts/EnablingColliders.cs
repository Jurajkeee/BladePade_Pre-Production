using UnityEngine;
using System.Collections;

public class EnablingColliders : MonoBehaviour
{
    private Transform childObj;
    private Transform childObjSecond;
	// Use this for initialization
	void Start ()
	{
	    childObj = transform.FindChild("Collider");
	    childObjSecond = transform.FindChild("Effectors");
        childObj.gameObject.SetActive(false);
        childObjSecond.gameObject.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Side" || collision.transform.tag == "LeftSide" || collision.transform.tag =="Ground")
        {
            childObj.gameObject.SetActive(true);
            childObjSecond.gameObject.SetActive(true);

        }
    }
}
