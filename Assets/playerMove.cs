using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    float jumpForce = 4000f;
    public Animator animator;
    Vector3 move;
    [SerializeField]
    bool jump = false;
    bool onGround = true;
    public GameObject text;
    public GameObject takis;
    public brushTeeth brush;

    // Update is called once per frame
    void Update()
    {
        float zMove = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * moveSpeed;
        float xMove = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * moveSpeed;

        move = transform.right * zMove + transform.forward * xMove;

        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("outOfBed") == false)
        {
            text.SetActive(false);
            takis.SetActive(true);
            animator.SetBool("outOfBed", true); 
        }

        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("outOfBed") == true)
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 4f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 2f;
        }
    }

    void FixedUpdate()
    {
        if (animator.GetBool("outOfBed") && brush.brushing == false)
        {
            GetComponent<Rigidbody>().MovePosition(move + new Vector3(transform.position.x, transform.position.y, transform.position.z));
        }

        if (jump && onGround && brush.brushing == false)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
            jump = false;
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag != "wall")
        {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag != "wall")
        {
            onGround = false;
        }
    }
}
