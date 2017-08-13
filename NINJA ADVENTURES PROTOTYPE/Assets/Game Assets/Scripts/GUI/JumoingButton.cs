using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class JumoingButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool jump;
    public int count;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
 

    public void OnPointerDown(PointerEventData eventData)
    {
        jump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        jump = false;
    }
}
