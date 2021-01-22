using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody theRB;
    private bool chasing;
    public float distanceToChase = 10f, distanceToLose = 15f;

    private Vector3 targetPoint, startPoint;

    // Start is called before the first frame update

    public NavMeshAgent agent;

    public float keepChasingTime = 5f;
    private float chaseCounter;


    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                chasing = true;
            }
        }
        else
        {
            //transform.LookAt(targetPoint);

            //theRB.velocity = transform.forward * moveSpeed;


            agent.destination = targetPoint;

            if(Vector3.Distance(transform.position, targetPoint) > distanceToLose)
            {
                chasing = false;

                agent.destination = startPoint;
            }
        }
    }
}
