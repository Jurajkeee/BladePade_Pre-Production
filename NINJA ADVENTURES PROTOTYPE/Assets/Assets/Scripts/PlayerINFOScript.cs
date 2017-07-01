using UnityEngine;
using System.Collections;

public class PlayerINFOScript : MonoBehaviour {
    public int skin;
    public int weapon;
    public int gold ;
    public int crystals;
    public int swords;
    public int health = 100;
    public float levelTime;
    public float energy;
    


    void Start () {
        skin = PlayerPrefs.GetInt("skin", 0);
        weapon = PlayerPrefs.GetInt("weapon", 0);
        gold = PlayerPrefs.GetInt("gold", 7000);
        crystals = PlayerPrefs.GetInt("crystals", 200);
        swords = PlayerPrefs.GetInt("swords", 0);
        
        levelTime = PlayerPrefs.GetInt("levelTime", 0);
        energy = PlayerPrefs.GetInt("energy", 0);
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
