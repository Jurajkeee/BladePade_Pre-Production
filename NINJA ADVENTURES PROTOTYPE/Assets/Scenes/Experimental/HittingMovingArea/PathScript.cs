using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PathScript : MonoBehaviour {
    public Color rayColor = Color.white;
    public List<Transform> path_objs = new List<Transform>();
    Transform[] theArray;
    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        path_objs.Clear();
        foreach(Transform path_obj in theArray)
        {
            if(path_obj != this.transform)
            {
                path_objs.Add(path_obj);
            }
        }
        for(int i = 0; i < path_objs.Count; i++)
        {
            Vector3 position = path_objs[i].position;
            if (i > 0)
            {
                Vector3 previos = path_objs[i - 1].position;
                Gizmos.DrawLine(previos, position);
                Gizmos.DrawSphere(position, 1);
            }
        }
    }
}
