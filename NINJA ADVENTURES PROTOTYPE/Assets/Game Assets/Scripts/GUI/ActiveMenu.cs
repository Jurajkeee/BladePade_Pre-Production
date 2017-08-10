using UnityEngine;
using System.Collections;

public class ActiveMenu : MonoBehaviour {
    public Canvas pause;
    public int levelid;
    public FinishScript finishScript;
	// Use this for initialization
	void Start () {
        finishScript = GameObject.Find("Finish").GetComponent<FinishScript>();
        pause.enabled = false;
        pause = pause.GetComponent<Canvas>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
    public void PausePressed()
    {
        pause.enabled = true;
        Time.timeScale = 0;

    }
    public void ResumePressed()
    {
        pause.enabled = false;
        Time.timeScale = 1;
    }
    public void MainMenuPressed()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1;
        finishScript.isFinished = false;

    }
    public void RestartPressed()
    {
        Application.LoadLevel(levelid);
        Time.timeScale = 1;
        finishScript.isFinished = false;
    }
}
