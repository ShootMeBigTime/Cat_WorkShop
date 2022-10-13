using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TeacherController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    public bool seesCat;
    private Animator teacherAnimator;

    public void Awake()
    {
        seesCat = false;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent.isStopped = true;
        teacherAnimator = GetComponent<Animator>();
    }

    public void setSeeCat(bool value)
    {
        seesCat = value;
    }
    public bool getSeeCat()
    {
        return seesCat;
    }
    public Transform getPlayerTransform()
    {
        return player.transform;
    }
    //---------------------------------------Idle-------------------------------
    public void onUpdateIdle()
    {
        //Do nothing
    }
    //---------------------------------------Follow-------------------------------
    public void onEnterFollow()
    {
        agent.isStopped = false;
        teacherAnimator.SetBool("seesCat", true);
    }
    public void onUpdateFollow()
    {
        agent.destination = getPlayerTransform().position;
    }
    public void onExitFollow()
    {
        agent.isStopped = true;
        teacherAnimator.SetBool("seesCat", false);
    }
    //---------------------------------------Pickup-------------------------------
    public void onEnterPickUp()
    {
        StartCoroutine(Pickup());
    }
    public IEnumerator Pickup()
    {
        Debug.Log("I have been activated");
        //Lock player in place
        //Make the cat fly to simulate pickup
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().AddForce(getPlayerTransform().up * 10);
        yield return new WaitForSeconds(3);
        //restart the level
        Application.LoadLevel(Application.loadedLevel);
    } 
}
