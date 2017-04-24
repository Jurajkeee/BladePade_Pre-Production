using UnityEngine;
using System.Collections;

public class CameraConnection : MonoBehaviour
{
    
    public GameObject objectToConnect;
    private Vector3 offset;
	// Use this for initialization
	void Start ()
	{
        offset = transform.position - objectToConnect.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate ()
	{
        transform.position = objectToConnect.transform.position + offset;

    }
}
