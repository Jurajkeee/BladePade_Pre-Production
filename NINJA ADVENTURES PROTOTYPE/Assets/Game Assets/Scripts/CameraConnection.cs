using UnityEngine;
using System.Collections;

public class CameraConnection : MonoBehaviour
{
    
    public GameObject objectToConnect;
    public GameObject camera;
	// Use this for initialization
	void Start ()
	{
        
    }
	
	// Update is called once per frame
	void LateUpdate ()
	{
        camera.transform.position = new Vector3(objectToConnect.transform.position.x, camera.transform.position.y, -3);

    }
}
