using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    float sensitivity = 100f;
    float xRot = 0f;
    public Animator animator;
    public bool firstOne = true;
    public brushTeeth brush;
    public GameObject brushImg;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GetComponentInParent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity; 

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        if (animator.GetBool("outOfBed") && firstOne)
        { 
            StartCoroutine(move());
        }

        else if (animator.GetBool("outOfBed") && brush.brushing == false)
        {
            player.Rotate(new Vector3(0, mouseX, 0));
            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }

        else if (brush.brushing == true)
        {
            player.transform.rotation = new Quaternion(0, 0, 0, 0);
            brushImg.SetActive(true);
            brushImg.transform.position = new Vector3(mouseX * 0.01f + brushImg.transform.position.x, mouseY * 0.01f + brushImg.transform.position.y, brushImg.transform.position.z);
        }
    }

    IEnumerator move()
    {
        yield return new WaitForSeconds(1);
        animator.enabled = false;
        firstOne = false;
        GetComponentInParent<BoxCollider>().enabled = true;
    }
}
