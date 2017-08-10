using UnityEngine;
using System.Collections;

public class ButtonUP : MonoBehaviour {
    public bool isTrue;
    public float timeBetweenChange = 1f;
    public float timeBetweenChange2 = 1f;
    private float timestamp;
    
    public Vector3 startingposition;
    // Use this for initialization
    void Start()
    {
        isTrue = false;
        
        startingposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (isTrue)
        {
            timestamp = Time.time + timeBetweenChange2;
            transform.position = new Vector3(startingposition.x, startingposition.y - 1.8F, 0);
        }
        if (Time.time >= timestamp && isTrue == false)
        {
            timestamp = Time.time + timeBetweenChange;
            transform.position = startingposition;

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" || collision.transform.name == "Sword (1)(Clone)")
        {
            isTrue = true;
            
            
            
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" || collision.transform.name == "Sword (1)(Clone)")
        {
            isTrue = false;
           


        }
    }

}
