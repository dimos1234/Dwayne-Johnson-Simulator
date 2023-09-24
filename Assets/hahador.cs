using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hahador : MonoBehaviour
{
    public Animator door;
    bool isopen = true;

    void OnTriggerEnter(Collider colliiderInfo)
    {
        Debug.Log("enter");
        if (colliiderInfo.tag == "Player")
        {
            if (isopen)
            {
                isopen = false;
                Debug.Log("open");
                door.SetBool("closeDoor", false);
                door.SetBool("openDoor", true);
            }

            else if (!isopen)
            {
                isopen = true;
                Debug.Log("close");
                door.SetBool("openDoor", false);
                door.SetBool("closeDoor", true);
            }
        }
    }
}
