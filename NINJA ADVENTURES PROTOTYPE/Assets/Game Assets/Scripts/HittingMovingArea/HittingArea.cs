using UnityEngine;
using System.Collections;

public class HittingArea : MonoBehaviour
{

    [SerializeField] private PlayerINFOScript playerInfoScript;
    [Range(1, 25)] public float damage;
    //Following the PATH


    void Start()
    {

        playerInfoScript = GameObject.Find("Player").GetComponent<PlayerINFOScript>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
            playerInfoScript.inputDamage = damage;

    }

}