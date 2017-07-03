using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LEVEL1 : MonoBehaviour {
    //SwordCounter
    public int swordCount;
    public Text swordCountGUI;
    public KeyCode Fire;
    public GameObject shooting2;
    public Shooting2 weaponScript;
    //Healthbar
    public GameObject player;
    public PlayerINFOScript info;
    public Text healthIndicator;
    public Image loading;
	
	void Start () {
        //SwordCounter
        UpdateScore();
        shooting2 = GameObject.Find("weapon");
        weaponScript = shooting2.GetComponent<Shooting2>();
        //HealthBar
        player = GameObject.Find("Player");
        info = player.GetComponent<PlayerINFOScript>();
        healthIndicator = healthIndicator.GetComponent<Text>();
        loading = loading.GetComponent<Image>();
	}
	
	
	void Update () {
        //HealthBar
        loading.fillAmount = info.health/100;
        healthIndicator.text = info.health.ToString();
        //SwordCounter
        if (Input.GetKeyDown(Fire)&&swordCount>0)
        {
            RemoveSword();
            
        }
        if (swordCount <= 0) weaponScript.enabled = false;
    }
    public void UpdateScore()
    {
        
            
            swordCountGUI.text = "" + swordCount;
        ;
        
    }
    public void RemoveSword()
    {
        swordCount--;
        UpdateScore();
        
    }
}
