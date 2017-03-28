using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour
{
    private Animator anims;
    private float vertical;
    private float horizontal;
    private Rigidbody2D body;
   
    private int collisionCount = 0;
    
    public KeyCode Fire = KeyCode.F;
    // Use this for initialization
    void Start()
    {
        
        anims = GetComponent<Animator>();
        anims.SetFloat("flying", 2);
        
        body = GetComponent<Rigidbody2D>();
        
        
        
}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        body.gravityScale = 0;
        body.isKinematic = true;
        anims.SetFloat("flying", -2);
        float angle = 0;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    // Update is called once per frame
    public void Update()
    {
        
        

    }
}