using UnityEngine;
using System.Collections;

public class PlayerINFOScript : MonoBehaviour {
    public int skin;
    public int weapon;
    public int gold ;
    public int crystals;
    public int swords;
    [Range(0,100)]public float health;
    public float levelTime;
    [Range(0,50)]public float energy;
    // Energy restoring
    


    void Start () {
        
        skin = PlayerPrefs.GetInt("skin", 0);
        weapon = PlayerPrefs.GetInt("weapon", 0);
        gold = PlayerPrefs.GetInt("gold", 0);
        crystals = PlayerPrefs.GetInt("crystals", 0);
        swords = PlayerPrefs.GetInt("swords", 0);
        
        levelTime = PlayerPrefs.GetInt("levelTime", 0);
        energy = PlayerPrefs.GetFloat("energy", 0);
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
	  

	}
}
