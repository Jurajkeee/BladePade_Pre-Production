using UnityEngine;
using System.Collections;

public class FliperScript : MonoBehaviour {
    public bool isFacingRight = true;
    private float horizontal;
    private Vector3 direction;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public PlayerControl playerControl;

    // Use this for initialization
    void Start () {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
    void Flip()
    {
        //Fliping completed and needed 1 00%
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;


    }
    // Update is called once per frame
    void Update () {
        if (horizontal > 0 && !isFacingRight)
            Flip();
        else if (horizontal < 0 && isFacingRight)
            Flip();
        if (transform.localScale.x < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
        }
        //left move needs to add anim Running
        if (Input.GetKey(leftButton))
        {
            horizontal = -1;



        }
        //right move needs to add anim Running
        else if (Input.GetKey(rightButton))
        {
            horizontal = 1;


        }
        else
            horizontal = 0;
        //Jumping needs to add anim Jumping

        



        direction = new Vector2(horizontal, 0);
    }
}
