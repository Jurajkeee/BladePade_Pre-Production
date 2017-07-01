using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
    //Scripts
    public PlayerINFOScript playerInfo;
    public GameObject player;
    public MenuScript menuScript;
    public GameObject menuGO;
    //Canvases
    
    //Variables
    public int costGold;
    public int costCryst;
    public int buttonClickedOnObjectForBuy;

    void Start () {
        menuGO = GameObject.Find("BeginningMenu");
        menuScript = menuGO.GetComponent<MenuScript>();
        player = GameObject.Find("PlayerInfoMenu");
        playerInfo = player.GetComponent<PlayerINFOScript>();
        
        
        // Enabling
       
	}
	
	
	void Update () {
	
	}
    public void BuyClicked()
    {
        
        if (buttonClickedOnObjectForBuy > 0)
        {
            menuScript.secondQuestion.enabled = true;
            menuScript.armourMenu.enabled = false;
        }
    }
    public void YesBut()
    {
        menuScript.secondQuestion.enabled = false;
        menuScript.armourMenu.enabled = true;
        if (playerInfo.gold >= costGold && playerInfo.crystals >= costCryst)
        {
            playerInfo.gold -= costGold;
            playerInfo.crystals -= costCryst;
            playerInfo.skin = buttonClickedOnObjectForBuy;
            menuScript.secondQuestion.enabled = false;
            menuScript.armourMenu.enabled = true;
        }
        else Debug.Log("Space for another canvas");
    }
    public void NoBut()
    {
        menuScript.secondQuestion.enabled = false;
        menuScript.armourMenu.enabled = true;
    }
    public void Skin1()
    {
        buttonClickedOnObjectForBuy = 1;
        costGold = 100;
        costCryst = 0;
    }
    public void Skin2()
    {
        buttonClickedOnObjectForBuy = 2;
        costGold = 1000;
        costCryst = 10;
    }
    public void Skin3()
    {
        buttonClickedOnObjectForBuy = 3;
        costGold = 5000;
        costCryst = 50;
    }
}
