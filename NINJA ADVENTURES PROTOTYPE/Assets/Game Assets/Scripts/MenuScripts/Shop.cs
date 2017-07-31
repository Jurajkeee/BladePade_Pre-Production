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
        menuGO = GameObject.Find("EventSystem");
        menuScript = menuGO.GetComponent<MenuScript>();
        player = GameObject.Find("PlayerInfoMenu");
        playerInfo = player.GetComponent<PlayerINFOScript>();
        
        
        // Enabling
       
	}
	
	
	void Update () {
        PlayerPrefs.SetFloat("costGold", costGold);
        PlayerPrefs.SetFloat("costCryst", costCryst);
        
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
    public void NotEnough()
    {
        
    }

}
