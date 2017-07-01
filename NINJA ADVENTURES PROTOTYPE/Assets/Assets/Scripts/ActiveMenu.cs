using UnityEngine;
using System.Collections;

public class ActiveMenu : MonoBehaviour {
    public Canvas pause;

	// Use this for initialization
	void Start () {
        pause = pause.GetComponent<Canvas>();
        pause.enabled = false; 

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
        Application.LoadLevel(1);
        Time.timeScale = 1;
    }
}
