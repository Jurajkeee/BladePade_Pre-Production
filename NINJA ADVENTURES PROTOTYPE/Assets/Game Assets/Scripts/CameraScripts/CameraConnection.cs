using UnityEngine;
using System.Collections;

public class CameraConnection : MonoBehaviour
{
    public Vector3 startPosition;
    public Transform objectToConnect;
    public Transform camera;
    public Vector3 difference;
    // Use this for initialization
    public DownCameraTriggered downCamera;
    public TopCameraTriggered topCamera;
	void Start ()
	{
        downCamera = GameObject.Find("Down").GetComponent<DownCameraTriggered>();
        topCamera = GameObject.Find("Top").GetComponent<TopCameraTriggered>();
        startPosition = objectToConnect.position;
        difference = camera.position - objectToConnect.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (downCamera.isTriggeringWithIT) camera.transform.position -= new Vector3(0, 5, 0); else camera.position = new Vector3(objectToConnect.transform.position.x, camera.position.y, -3); 
        if (topCamera.isTriggeringWithIT) camera.transform.position += new Vector3(0, 5, 0); else camera.position = new Vector3(objectToConnect.transform.position.x, camera.position.y, -3); 
    }
    void LateUpdate ()
	{
        camera.transform.position = new Vector3(objectToConnect.transform.position.x + difference.x,camera.transform.position.y, -3);

    }
}
