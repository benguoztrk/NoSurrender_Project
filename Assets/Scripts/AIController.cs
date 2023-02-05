using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public GameObject[] AllPlayers;
    public GameObject nearestPlayer;
    float distance;
    float nearestDistance= 10000;
    private Animator opponentAnim;

    //public Transform player;
    public NavMeshAgent navMesh;
    
    void Start()
    {
        //Find players with the tag name Player and put it into AllPlayers Array. Update the nearestPlayer according to the distance
        AllPlayers = GameObject.FindGameObjectsWithTag("Player");

        for (int i=0; i<AllPlayers.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, AllPlayers[i].transform.position);
            if (distance < nearestDistance)
            {
                nearestPlayer = AllPlayers[i];
                nearestDistance = distance;
            }
            if (distance == 0)
            {
                nearestPlayer = AllPlayers[i+1];
            }
        }

        opponentAnim.SetBool("IsMoving", true);

    }
    private void Awake()
    {
       navMesh = GetComponent<NavMeshAgent>();
       opponentAnim= GetComponent<Animator>();



    }
   
    void Update()
    {
       
        navMesh.destination = nearestPlayer.transform.position;
       

        
    }

   
    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "GameOver")
        {
            UIController.instance.scoreValue += 100;  //If any navmesh agent trigger the platfrom collider, score increases by 100
            print("platform collider triggered");
           
        }
    }

}
