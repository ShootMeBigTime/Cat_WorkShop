using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerTeacher : MonoBehaviour
{

    public GameObject teacherConnected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            teacherConnected.GetComponent<TeacherController>().setSeeCat(true);
        }
    }
}
