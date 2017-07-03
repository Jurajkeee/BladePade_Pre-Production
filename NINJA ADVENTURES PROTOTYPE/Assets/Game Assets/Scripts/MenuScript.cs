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
    public Canvas secondQuestionWeapon;
    //EnergyBarGUI
    public PlayerINFOScript playerInfoSC;
    public GameObject playerInfoMenu;
    public Image energyBar;
    public Text energyBarIndicator;

    void Start() {
        //EnergyBar
        energyBar = energyBar.GetComponent<Image>();
        energyBarIndicator = energyBarIndicator.GetComponent<Text>();
        playerInfoMenu = GameObject.Find("PlayerInfoMenu");
        playerInfoSC = playerInfoMenu.GetComponent<PlayerINFOScript>();
        UpdateEnergyBar();

        //Canvases
        secondQuestionWeapon = secondQuestionWeapon.GetComponent<Canvas>();
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
        secondQuestionWeapon.enabled = false;
    }
    private void Update()
    {
        UpdateEnergyBar();
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
        RemoveEnergy();
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
    //EnergyBar
    public void UpdateEnergyBar()
    {
        float ratio = playerInfoSC.energy / 50;
        energyBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        energyBarIndicator.text = playerInfoSC.energy.ToString();

    }
    public void RemoveEnergy()
    {
        playerInfoSC.energy -= 10;
        UpdateEnergyBar();
    }

}
	
	
	

