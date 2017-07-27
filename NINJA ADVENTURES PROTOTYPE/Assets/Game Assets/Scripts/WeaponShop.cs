using UnityEngine;
using System.Collections;

public class WeaponShop : MonoBehaviour
{
    //Scripts
    public PlayerINFOScript playerInfo;
    public GameObject player;
    public MenuScript menuScript;
    public GameObject menuGO;
    //Canvases

    //Variables
    public int costGold;
    public int costCryst;
    public int buttonClickedOnObjectForBuy1;

    void Start()
    {
        menuGO = GameObject.Find("EventSystem");
        menuScript = menuGO.GetComponent<MenuScript>();
        player = GameObject.Find("PlayerInfoMenu");
        playerInfo = player.GetComponent<PlayerINFOScript>();


        // Enabling

    }


    void Update()
    {
        PlayerPrefs.SetFloat("costGoldWeapon", costGold);
        PlayerPrefs.SetFloat("costCrystWeapon", costCryst);

    }
   
    
    
    public void WeaponSkin1()
    {
        buttonClickedOnObjectForBuy1 = 1;
        costGold = 100;
        costCryst = 0;
    }
    public void WeaponSkin2()
    {
        buttonClickedOnObjectForBuy1 = 2;
        costGold = 1000;
        costCryst = 10;
    }
    public void WeaponSkin3()
    {
        buttonClickedOnObjectForBuy1 = 3;
        costGold = 5000;
        costCryst = 50;
    }
}

