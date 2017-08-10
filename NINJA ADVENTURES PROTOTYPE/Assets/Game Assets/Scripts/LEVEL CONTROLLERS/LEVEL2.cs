using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LEVEL2 : MonoBehaviour {
    //Timer
    public Text timer;
    //SwordCounter
    
    public Text swordCountGUI;
    public KeyCode Fire;
    public GameObject shooting2;
    public Shooting2 weaponScript;
    public Image bg_swordcounter;
    public int goldAchieve;
    public int silverAchieve;
    public int bronzeAchieve;
    //Healthbar
    public GameObject player;
    public PlayerINFOScript info;
    
    public Text healthIndicator;
    public Image loading;
    //Results
    public FinishScript finishScript;
    public Canvas resultCanvas;
    public Image bG_result;
    public Image medal_1;
    public Image medal_2;
    public Image medal_3;
    public Image time_1;
    public Text time_on_level;
    public int coinsPicked;
    public float succesfulTime;
    // Coins Adding
    public int added;
    


    void Start()
    {
        //SwordCounter
        
        shooting2 = GameObject.Find("weapon");
        weaponScript = shooting2.GetComponent<Shooting2>();
        bg_swordcounter = bg_swordcounter.GetComponent<Image>();
        bg_swordcounter.color = new Color32(255, 255, 68, 255);
        //HealthBar
        player = GameObject.Find("Player");
        info = player.GetComponent<PlayerINFOScript>();
        healthIndicator = healthIndicator.GetComponent<Text>();
        loading = loading.GetComponent<Image>();
        //Results
        finishScript = GameObject.Find("Finish").GetComponent<FinishScript>();
        resultCanvas = resultCanvas.GetComponent<Canvas>();
        bG_result = bG_result.GetComponent<Image>();
        medal_1 = medal_1.GetComponent<Image>();
        medal_2 = medal_2.GetComponent<Image>();
        medal_3 = medal_3.GetComponent<Image>();
        time_1 = time_1.GetComponent<Image>();
        time_on_level = time_on_level.GetComponent<Text>();
        resultCanvas.enabled = false;
        time_1.enabled = false;
        timer = timer.GetComponent<Text>();
        added = 0;

    }


    void Update()
    {
        timer.text = info.level2NewTime.ToString();
        //HealthBar
        loading.fillAmount = info.health / 100;
        healthIndicator.text = info.health.ToString();
        //SwordCounter
        swordCountGUI.text = weaponScript.Counter.ToString();
        if (weaponScript.Counter > goldAchieve)
        {
            bg_swordcounter.color = new Color32(244, 244, 244, 255);
            bG_result.color = new Color32(244, 244, 244, 255);

        }
        if (weaponScript.Counter > bronzeAchieve)
        {
            bg_swordcounter.color = new Color32(255, 174, 0, 255);
            bG_result.color = new Color32(255, 174, 0, 255);
        }
        switch (coinsPicked)
        {
            case 0:
                medal_1.enabled = false;
                medal_2.enabled = false;
                medal_3.enabled = false;
                break;
            case 1:
                medal_1.enabled = true;
                break;
            case 2:
                medal_1.enabled = true;
                medal_2.enabled = true;
                break;
            case 3:
                medal_1.enabled = true;
                medal_2.enabled = true;
                medal_3.enabled = true;
                break;
            default:
                medal_1.enabled = false;
                medal_2.enabled = false;
                medal_3.enabled = false;
                break;

        }
        if (succesfulTime >= info.level2NewTime) time_1.enabled = true; else time_1.enabled = false;
        if (finishScript.isFinished)
        {
            resultCanvas.enabled = true;
            time_on_level.text = info.level2NewTime.ToString();
            added++;
            if (added == 1)
            {
                if (weaponScript.Counter < goldAchieve) info.gold += 1000;
                if (weaponScript.Counter > goldAchieve && weaponScript.Counter < bronzeAchieve) info.gold += 500;
                if (weaponScript.Counter > bronzeAchieve) info.gold += 100;
                if (info.level2NewTime < succesfulTime) info.gold += 250;
                info.crystals += coinsPicked * 10;
            }
            //

        }
    }
    
    
    public void ContinuePressed()
    {        finishScript.isFinished = false;
        Application.LoadLevel(0);
        Time.timeScale = 1;
    }
    private void OnDestroy()
    {
    }


}

