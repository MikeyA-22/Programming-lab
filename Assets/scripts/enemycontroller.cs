using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller : MonoBehaviour
{

    public GameObject Player;
    public float Distance;

    public bool isNear;

    public NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);



        if(Distance <= 5)
        {
            isNear = true;
        }
        if(Distance >5f)
        {
            isNear = false;
        }


        if(isNear)
        {
            _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);
        }
        if(!isNear)
        {
            _agent.isStopped = true;
        }

    }
}
