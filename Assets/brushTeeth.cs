using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brushTeeth : MonoBehaviour
{
    public bool brushing = false;
    public Vector3 brushingPos = new Vector3(-3f, 4.7f, 0);
    public Quaternion brushigQuat = new Quaternion(32.7f, 187f, 4.5f, 0f);
    
    void OnTriggerEnter(Collider colliderInfo)
    {
        brushing = true;
    }

    void Update()
    {
        
    }
}
