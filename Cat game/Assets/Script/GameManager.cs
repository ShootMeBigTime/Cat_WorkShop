using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pickupText;
    public TextMeshProUGUI findKeycardText;
    void Start()
    {
        findKeycardText.gameObject.SetActive(false);
    }

    // UI element displaying wheter or not player has the keycard
    public void PickupStatus(bool pickupCounter)
    {
        if (pickupCounter == false)
        {
            pickupText.text = ("Find the keycard!");
        }
        else
        {
            pickupText.text = ("Keycard get!");
        }
    }

    // UI element appears that tells the player to get the keycard
    public void FindKeycard()
    {
        StartCoroutine(FindKeycardCouroutine());
    }
    IEnumerator FindKeycardCouroutine()
    {
        findKeycardText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        findKeycardText.gameObject.SetActive(false);
    }
}
