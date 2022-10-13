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

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        // Add wheter or not you have the keycard to the Game Manager UI
        gameManager.PickupStatus(pickupCounter);
        if (Input.GetMouseButton(0))
        {
            Ray clawRay = new Ray(transform.position, transform.forward * distance);
            RaycastHit clawHit;
            if (Physics.Raycast(clawRay, out clawHit))
            {
                // If you claw at a rigidbody, add force to it
                if (clawHit.rigidbody)
                {
                    clawHit.rigidbody.AddForceAtPosition(force * transform.forward, clawHit.point);
                }
                // If you claw the keycard, pick it up
                if (clawHit.collider.CompareTag("Pickup"))
                {
                    clawHit.collider.gameObject.SetActive(false);
                    pickupCounter = true;
                }
                // If you claw the reader and you have the keycard, "open the door" aka set it inactive
                if (clawHit.collider.CompareTag("Reader") && pickupCounter)
                {
                    door = GameObject.FindGameObjectWithTag("Door");
                    door.SetActive(false);
                }
                // If you claw the reader and you dont have the keycard, display UI element telling player to find the keycard
                else if (clawHit.collider.CompareTag("Reader") && pickupCounter == false)
                {
                    gameManager.FindKeycard();
                }
            }
        }
    }
    // Draw raycast for the scratch
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }
}
