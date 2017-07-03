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
    public int buttonClickedOnObjectForBuy;

    void Start()
    {
        menuGO = GameObject.Find("BeginningMenu");
        menuScript = menuGO.GetComponent<MenuScript>();
        player = GameObject.Find("PlayerInfoMenu");
        playerInfo = player.GetComponent<PlayerINFOScript>();


        // Enabling

    }


    void Update()
    {

    }
    public void BuyClicked()
    {

        if (buttonClickedOnObjectForBuy > 0)
        {
            menuScript.secondQuestionWeapon.enabled = true;
            menuScript.weaponMenu.enabled = false;
        }
    }
    public void YesBut()
    {
        menuScript.secondQuestionWeapon.enabled = false;
        menuScript.weaponMenu.enabled = true;
        if (playerInfo.gold >= costGold && playerInfo.crystals >= costCryst)
        {
            playerInfo.gold -= costGold;
            playerInfo.crystals -= costCryst;
            playerInfo.weapon = buttonClickedOnObjectForBuy;
            menuScript.secondQuestionWeapon.enabled = false;
            menuScript.weaponMenu.enabled = true;
        }
        else Debug.Log("Space for another canvas");
    }
    public void NoBut()
    {
        menuScript.secondQuestionWeapon.enabled = false;
        menuScript.weaponMenu.enabled = true;
    }
    public void WeaponSkin1()
    {
        buttonClickedOnObjectForBuy = 1;
        costGold = 100;
        costCryst = 0;
    }
    public void WeaponSkin2()
    {
        buttonClickedOnObjectForBuy = 2;
        costGold = 1000;
        costCryst = 10;
    }
    public void WeaponSkin3()
    {
        buttonClickedOnObjectForBuy = 3;
        costGold = 5000;
        costCryst = 50;
    }
}

