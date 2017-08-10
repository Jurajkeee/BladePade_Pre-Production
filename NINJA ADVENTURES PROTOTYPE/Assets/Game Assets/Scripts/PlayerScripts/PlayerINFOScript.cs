using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerINFOScript : MonoBehaviour {
    public float onLevel;
    public int skin;
    public int weapon;
    public int gold ;
    public int crystals;
    public int swords;
    [Range(0,100)]public float health;
    
    [Range(0,100)]public float energy;
    public EnergyTimer energyTimer;
    // Energy restoring
    
    //Enemy
    public float timeBetweenHits = 0.5f;
    private float timestamp;
    public float inputDamage;
    //Results
    
    public float level1BestTime;
    public float level1NewTime;
    public FinishScript finishScript;
    // Level 2
    public float level2BestTime;
    public float level2NewTime;
    void Start () {
        
        energyTimer = GameObject.Find("EventSystem").GetComponent<EnergyTimer>();
        skin = PlayerPrefs.GetInt("skin");
        weapon = PlayerPrefs.GetInt("weapon");
        gold = PlayerPrefs.GetInt("gold");
        crystals = PlayerPrefs.GetInt("crystals");
        swords = PlayerPrefs.GetInt("swords");

        level1BestTime = PlayerPrefs.GetFloat("Level1BestTime");
        energy = PlayerPrefs.GetFloat("energy");
        // Energy restoring
        // Results
        finishScript = GameObject.Find("Finish").GetComponent<FinishScript>();
        //Level 2
        level2BestTime = PlayerPrefs.GetFloat("Level2BestTime");

    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("skin",skin);
        PlayerPrefs.SetInt("weapon", weapon);
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("crystals", crystals);
        PlayerPrefs.SetInt("swords", swords);
        
       
        PlayerPrefs.SetFloat("energy", energy);
        


    }
    private void Awake()
    {
       
    }
    void Update ()
    {
        if (finishScript != null)
        {
            if (finishScript.isFinished && (level1NewTime < level1BestTime || level1BestTime == 0) && onLevel==1)
            {
                PlayerPrefs.SetFloat("Level1BestTime", level1NewTime);
                print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            }
            if (finishScript.isFinished && (level2NewTime < level2BestTime || level2BestTime == 0) && onLevel == 2)
            {
                PlayerPrefs.SetFloat("Level2BestTime", level2NewTime);
                print("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
            }
            if (finishScript.isFinished)
            {
                Time.timeScale = 0;
            }
        }
        if (onLevel == 1)
        level1NewTime += Time.deltaTime;
        if(onLevel == 2)
        level2NewTime += Time.deltaTime;
        if (energyTimer != null)
        
            energy = energyTimer.eenergy;
        if (health <= 0) {
            health = 0;
            Time.timeScale = 0;
        }
        
        
        
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name == "Enemy")
        {

            if (Time.time >= timestamp)
            {
                health -= inputDamage;
                timestamp = Time.time + timeBetweenHits;
                
            }
        }
    }

}
