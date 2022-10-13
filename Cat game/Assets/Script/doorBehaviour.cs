using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    public bool openDoor = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("yee");

            animator.SetBool("isCollisionTriggered", true);

            var isDoorOpen = animator.GetBool("isDoorOpen");
            var isDoorClosed = animator.GetBool("isDoorClosed");

            if ((!isDoorOpen && !isDoorClosed) && openDoor == true)
            {
                animator.SetBool("isDoorOpen", true);
            }
            else if ((isDoorOpen || isDoorClosed))
            {
                animator.SetBool("isDoorOpen", false);
                animator.SetBool("isDoorClosed", false);
            }
            else if ((!isDoorOpen && !isDoorClosed) && openDoor == false)
            {
                animator.SetBool("isDoorClosed", true);
            }
        }
    }
}
