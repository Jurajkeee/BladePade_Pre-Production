using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class EnergyTimer : MonoBehaviour {
    public Text onlineTimerUI;

    //
    public TimeSpan difference;
   
    
    //
    
    public float onlineTimer;
    public DateTime currentDateTime;
    public DateTime startingTime;
    public DateTime endingTime;
    public float savedOnlineTimer;
    public float remnant;
    public bool isOnlineTimerActive = true;
    public float eenergy;
    //

    //
    
    public PlayerINFOScript playerInfoScript;
    // DEBUG
    public float insertingVariableDEBUG;
	void Start () {
        
        startingTime = DateTime.Now;
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
        endingTime = DateTime.FromBinary(temp);

        eenergy = 0;
        eenergy = PlayerPrefs.GetFloat("energy");
        //Debug
        print("EnergyOnEnter" + eenergy);
        print("OldTime" + endingTime);
        print("Curent Time" + startingTime);
        //
      
        
        
        difference = startingTime - endingTime;
        
        savedOnlineTimer = PlayerPrefs.GetFloat("savedOT");
        print("Saved Timer" + savedOnlineTimer);
        if (difference.Seconds>=20) 
        {
        
        
           remnant = (difference.Hours * 60 * 60 + difference.Minutes * 60 + difference.Seconds + savedOnlineTimer) % 20;
           onlineTimer += remnant;
            float addedEnergy = ((difference.Hours * 60 * 60 + difference.Minutes * 60 + difference.Seconds + savedOnlineTimer - remnant) / 20) ;
           eenergy += addedEnergy;
            //
            print("added energy" + addedEnergy);
        }
        else onlineTimer = savedOnlineTimer+difference.Seconds;
        // DEBUG {
        print("Difference:"+ difference.Seconds.ToString());
        print("Remnant:"+ remnant);
        print("Online Timer: " + onlineTimer);
        

        //       }
        playerInfoScript = GameObject.Find("PlayerInfoMenu").GetComponent<PlayerINFOScript>();
        //
              
	}
    private void OnApplicationQuit()
    {
        
        PlayerPrefs.SetString("sysString", DateTime.Now.ToBinary().ToString());
        savedOnlineTimer = onlineTimer;
        PlayerPrefs.SetFloat("savedOT", savedOnlineTimer);
        isOnlineTimerActive = false;
        print("Saved Timer" + savedOnlineTimer);
        
        PlayerPrefs.SetFloat("energy", eenergy);
        //DEBUG
        print("Energy On Exit" + eenergy);
        //
        
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetString("sysString", DateTime.Now.ToBinary().ToString());
        savedOnlineTimer = onlineTimer;
        PlayerPrefs.SetFloat("savedOT", savedOnlineTimer);
        isOnlineTimerActive = false;
        print("Saved Timer" + savedOnlineTimer);
       
        PlayerPrefs.SetFloat("energy", eenergy);
        //DEBUG
        print("Energy On Exit" + eenergy);
        
        //
    }
    // Update is called once per frame
    void Update () {
       
        onlineTimerUI.text = Mathf.Round(((20 - onlineTimer)*1000f)/1000f).ToString();



        if (isOnlineTimerActive == true)

            onlineTimer += Time.deltaTime;
        if (eenergy < 100)
        {
            isOnlineTimerActive = true;
        }
        

        if (onlineTimer >= 20)
        {
            onlineTimer = 0.01F;
            eenergy++;
        }
        if (eenergy > 100)
        {
            eenergy = 100;
            
            

        }
        if (eenergy == 100)
        {
            onlineTimer = 0.01F;
            isOnlineTimerActive = false;
            onlineTimerUI.text = "";
        }

    }
 
}
