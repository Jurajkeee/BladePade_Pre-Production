using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
    public GameObject gameObjectWithLevelController;
    public int levelid;

    public LEVEL1 level1;
    public LEVEL2 level2;
	// Use this for initialization
	void Start () {
        level1 = level1.GetComponent<LEVEL1>();
        level2 = level2.GetComponent<LEVEL2>();
        
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
                switch (levelid)
                {
                    case 1:
                        level1.coinsPicked++;
                        break;
                    case 2:
                        level2.coinsPicked++;
                        break;
                    default:
                        break;
                }
                Destroy(gameObject);
            }
        }
        
    }
}
