using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerINFOScript : MonoBehaviour {
    public int skin;
    public int weapon;
    public int gold ;
    public int crystals;
    public int swords;
    [Range(0,100)]public float health;
    public float levelTime;
    [Range(0,100)]public float energy;
    public EnergyTimer energyTimer;
    // Energy restoring
   
    void Start () {

        energyTimer = GameObject.Find("EventSystem").GetComponent<EnergyTimer>();
        skin = PlayerPrefs.GetInt("skin");
        weapon = PlayerPrefs.GetInt("weapon");
        gold = PlayerPrefs.GetInt("gold");
        crystals = PlayerPrefs.GetInt("crystals");
        swords = PlayerPrefs.GetInt("swords");
        
        levelTime = PlayerPrefs.GetInt("levelTime");
        energy = PlayerPrefs.GetFloat("energy");
        // Energy restoring
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("skin",skin);
        PlayerPrefs.SetInt("weapon", weapon);
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("crystals", crystals);
        PlayerPrefs.SetInt("swords", swords);
        
        PlayerPrefs.SetFloat("levelTime", levelTime);
        PlayerPrefs.SetFloat("energy", energy);

    }
    private void Awake()
    {
       
    }
    void Update ()
    {
        if (energyTimer != null)
        
            energy = energyTimer.eenergy;
        
	}
 
}
