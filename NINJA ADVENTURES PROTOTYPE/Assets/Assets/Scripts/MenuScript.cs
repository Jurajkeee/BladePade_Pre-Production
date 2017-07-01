using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {
    //Initializing Canvases
    public Canvas begginingMenu;
    public Canvas mainMenu;
    public Canvas chaptersMenu;
    public Canvas levelMenu;
    public Canvas shopMenu;
    public Canvas armourMenu;
    public Canvas weaponMenu;
    public Canvas secondQuestion;
    //Initializing Buttons
  

    void Start() {
        //Canvases
        begginingMenu = begginingMenu.GetComponent<Canvas>();
        mainMenu = mainMenu.GetComponent<Canvas>();
        chaptersMenu = chaptersMenu.GetComponent<Canvas>();
        levelMenu = levelMenu.GetComponent<Canvas>();
        shopMenu = shopMenu.GetComponent<Canvas>();
        armourMenu = armourMenu.GetComponent<Canvas>();
        weaponMenu = weaponMenu.GetComponent<Canvas>();
        //Buttons

        //Enabling Menus
        
        begginingMenu.enabled = true;
        mainMenu.enabled = false;
        chaptersMenu.enabled = false;
        levelMenu.enabled = false;
        shopMenu.enabled = false;
        armourMenu.enabled = false;
        weaponMenu.enabled = false;
        secondQuestion.enabled = false;
    }
   
    public void StartPress()
    {
        begginingMenu.enabled = false;
        mainMenu.enabled = true;
    }
    public void PlayPress()
    {
        chaptersMenu.enabled = true;
        mainMenu.enabled = false;
    }
    public void Chapter1ButPress()
    {
        levelMenu.enabled = true;
        chaptersMenu.enabled = false;
    }
    public void Level1ButPress()
    {
        Application.LoadLevel(0);
    }
    public void ShopButPress()
    {
        shopMenu.enabled = true;
        mainMenu.enabled = false;
    }
    public void SkinsShopBotPress()
    {
        armourMenu.enabled = true;
        shopMenu.enabled = false;
    }
    public void WeaponShopButPress()
    {
        weaponMenu.enabled = true;
        shopMenu.enabled = false;
    }
    public void CMBut()
    {
        chaptersMenu.enabled = false;
        mainMenu.enabled = true;
    }
    public void LCBut()
    {
        levelMenu.enabled = false;
        chaptersMenu.enabled = true;
    }
    public void SMBut()
    {
        shopMenu.enabled = false;
        mainMenu.enabled = true;
    }
    public void ASBut()
    {
        armourMenu.enabled = false;
        shopMenu.enabled = true;
    }
    public void WSBut()
    {
        weaponMenu.enabled = false;
        shopMenu.enabled = true;
    }


}
	
	
	

