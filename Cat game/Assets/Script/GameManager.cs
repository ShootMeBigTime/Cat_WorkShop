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
    // Start is called before the first frame update
    void Start()
    {
        findKeycardText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
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
