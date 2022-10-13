using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class clawScratch : MonoBehaviour
{
    float force = 200f;
    float distance = 5f;
    bool pickupCounter = false;
    public GameObject door;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.PickupStatus(pickupCounter);
        if (Input.GetMouseButton(0))
        {
            Ray clawRay = new Ray(transform.position, transform.forward * distance);
            RaycastHit clawHit;
            if (Physics.Raycast(clawRay, out clawHit))
            {
                if (clawHit.rigidbody)
                {
                    clawHit.rigidbody.AddForceAtPosition(force * transform.forward, clawHit.point);
                }
                if (clawHit.collider.CompareTag("Pickup"))
                {
                    clawHit.collider.gameObject.SetActive(false);
                    pickupCounter = true;
                }
                if (clawHit.collider.CompareTag("Reader") && pickupCounter)
                {
                    door = GameObject.FindGameObjectWithTag("Door");
                    door.SetActive(false);
                } else if (clawHit.collider.CompareTag("Reader") && pickupCounter == false)
                {
                    gameManager.FindKeycard();
                }
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }
}
