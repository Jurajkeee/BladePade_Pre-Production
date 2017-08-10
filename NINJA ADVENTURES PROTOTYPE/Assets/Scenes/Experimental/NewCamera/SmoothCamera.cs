using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {
    public Transform lookAt;
    [SerializeField] private bool smooth = true;
    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0, 0, -6.5f);
	// Use this for initialization
	
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 desiredPosition = new Vector3(lookAt.transform.position.x, lookAt.transform.position.y, lookAt.transform.position.z)+ offset ;
        if (smooth)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
        else
        {
            transform.position = desiredPosition;
        }
	}
}
