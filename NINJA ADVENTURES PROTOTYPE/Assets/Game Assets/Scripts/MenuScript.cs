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
    public EnergyTimer energyTimer;
    
    public Image energyBar;
    public Text energyBarIndicator;
    public Canvas notEnoughtEnergy;
    //Money
    public Text gold;
    public Text crystals;
    public Text goldCostArUI;
    public Text crystalCostArUI;
    public Text goldCostWUI;
    public Text crystalCostWUI;
    //SHOPING
    public Shop armourShopInfo;
    public WeaponShop weaponShopInfo;
    public float goldCost;
    public float crystalCost;
    public float goldCostW;
    public float crystalCostW;
    public Canvas notEnoughMoney;
    public Text notEnoughMoneyText;
    // DEBUG
    public float insertingVariableDEBUG;
    void Start() {
        weaponShopInfo = GameObject.Find("WeaponShoop").GetComponent<WeaponShop>();
        armourShopInfo = GameObject.Find("ArmourShop").GetComponent<Shop>();
        //money
        gold = gold.GetComponent<Text>();
        crystals = crystals.GetComponent<Text>();
        goldCostArUI = goldCostArUI.GetComponent<Text>();
        crystalCostArUI = crystalCostArUI.GetComponent<Text>();
        goldCostWUI = goldCostWUI.GetComponent<Text>();
        crystalCostWUI = crystalCostWUI.GetComponent<Text>();
        //EnergyBar
        notEnoughtEnergy = notEnoughtEnergy.GetComponent<Canvas>();
        energyBar = energyBar.GetComponent<Image>();
        energyBarIndicator = energyBarIndicator.GetComponent<Text>();
        playerInfoMenu = GameObject.Find("PlayerInfoMenu");
        playerInfoSC = playerInfoMenu.GetComponent<PlayerINFOScript>();
        energyTimer = GameObject.Find("EventSystem").GetComponent<EnergyTimer>();
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
        //shoping
        notEnoughMoney = notEnoughMoney.GetComponent<Canvas>();
        notEnoughMoney.enabled = false;
        notEnoughMoneyText = notEnoughMoneyText.GetComponent<Text>();
        //Enabling Menus
        notEnoughtEnergy.enabled = false;
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

        goldCostArUI.text = goldCost.ToString();
        crystalCostArUI.text = crystalCost.ToString();
        goldCostWUI.text = goldCostW.ToString();
        crystalCostWUI.text = crystalCostW.ToString();
        goldCost = PlayerPrefs.GetFloat("costGold");
        crystalCost = PlayerPrefs.GetFloat("costCryst");
        //
        goldCostW = PlayerPrefs.GetFloat("costGoldWeapon");
        crystalCostW = PlayerPrefs.GetFloat("costCrystWeapon");
        
            
        //
        UpdateEnergyBar();
        UpdateCrystals();
        UpdateGold();
        
        
    }
    public void BuyClickedArmour()
    {
        if (armourShopInfo.buttonClickedOnObjectForBuy > 0)
        {
            secondQuestion.enabled = true;
            armourMenu.enabled = false;
        }
    }
    public void BuyClickedWeapon()
    {
        if (weaponShopInfo.buttonClickedOnObjectForBuy1 > 0)
        {
            secondQuestionWeapon.enabled = true;
            weaponMenu.enabled = false;
        }
    }
    public void YesButArmour()
    {
        armourShopInfo.buttonClickedOnObjectForBuy = 0;
        secondQuestion.enabled = false;
        armourMenu.enabled = true;
        if (playerInfoSC.gold >= goldCost && playerInfoSC.crystals >= crystalCost)
        {
            playerInfoSC.gold -= (int)goldCost;
            playerInfoSC.crystals -= (int)crystalCost;
            playerInfoSC.skin = armourShopInfo.buttonClickedOnObjectForBuy;


        }
        else NotEnoughMoneyEnergy();
        secondQuestion.enabled = false;
        armourMenu.enabled = true;
    }
    public void NoButArmour()
    {
        armourShopInfo.buttonClickedOnObjectForBuy = 0;
        secondQuestion.enabled = false;
        armourMenu.enabled = true;
    }
    public void WeaponYesBut()
    {
        weaponShopInfo.buttonClickedOnObjectForBuy1 = 0;
        secondQuestionWeapon.enabled = false;
        weaponMenu.enabled = true;
        if (playerInfoSC.gold >= goldCostW && playerInfoSC.crystals >= crystalCostW)
        {
            playerInfoSC.gold -= (int)goldCostW;
            playerInfoSC.crystals -= (int)crystalCostW;
            playerInfoSC.weapon = weaponShopInfo.buttonClickedOnObjectForBuy1;
            secondQuestionWeapon.enabled = false;
            weaponMenu.enabled = true;
        }
        else NotEnoughMoneyEnergy();
    }
    public void WeaponNoBut()
    {
        weaponShopInfo.buttonClickedOnObjectForBuy1 = 0;
        secondQuestionWeapon.enabled = false;
        weaponMenu.enabled = true;
    }
    public void UpdateGold()
    {
        gold.text = playerInfoSC.gold.ToString();
    }
    public void UpdateCrystals()
    {
        crystals.text = playerInfoSC.crystals.ToString();
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
        if (playerInfoSC.energy >= 10)
        {
            RemoveEnergy();
            UpdateEnergyBar();
            Application.LoadLevel(0);
        } else
        {
            notEnoughtEnergy.enabled = true;
            levelMenu.enabled = false;
        }

    }
    public void NotEnoughtEnergyOK()
    {
        notEnoughtEnergy.enabled = false;
        levelMenu.enabled = true;
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
        float ratio = playerInfoSC.energy / 100;
        energyBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        energyBarIndicator.text = playerInfoSC.energy.ToString();

    }
    public void RemoveEnergy()
    {
        playerInfoSC.energy -= 10;
        energyTimer.eenergy -= 10;
        print("EnergyRemoved");
        
        
    }
    public void NotEnoughMoneyEnergy()
    {
        notEnoughMoney.enabled = true;
        if (goldCost > playerInfoSC.gold || goldCostW > playerInfoSC.gold)
        {
            
            notEnoughMoneyText.text = "Not enough Gold";

        }
        if(crystalCost > playerInfoSC.crystals || crystalCostW > playerInfoSC.crystals)
        {
            notEnoughMoneyText.text = "Not enough Crystals";
        }
    }
    public void NotEnoughOkPressed()
    {
        notEnoughMoney.enabled = false;
    }
   
}
	
	
	

