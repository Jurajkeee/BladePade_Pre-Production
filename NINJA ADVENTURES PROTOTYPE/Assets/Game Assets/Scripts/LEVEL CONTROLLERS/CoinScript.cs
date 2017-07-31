using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
    public GameObject gameObjectWithLevelController;
    public LEVEL1 level1;
	// Use this for initialization
	void Start () {
        level1 = gameObjectWithLevelController.GetComponent<LEVEL1>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObjectWithLevelController != null)
        {
            if (collision.transform.tag == "Player" || collision.transform.name == "Sword (1)(Clone)")
            {
                level1.coinsPicked++;
                Destroy(gameObject);
            }
        }
        
    }
}
