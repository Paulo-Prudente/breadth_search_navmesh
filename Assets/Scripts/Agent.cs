using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    public Transform[] target;
    public Transform home;
    public bool[] empty;

    //Queue<Transform> fila = new Queue<Transform>();

    Vector3 newDestination;
    NavMeshAgent agent;

    public int contador=0;

    void Start()
    {
        //fila.Enqueue(target[contador]);

        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        newDestination = target[contador].position;
    }
        
    void Update()
    {

        NavMeshHit hit;
        if (agent.Raycast(newDestination, out hit))
        {
            print("hit destino: " + newDestination);
            agent.SetDestination(newDestination);
        }

        if (Vector3.Distance(agent.transform.position, target[contador].position) < 3)
        {
            print("opa cheguei no destination, vamo pra casa");

            contador++;
            print("contador: " + contador);

            newDestination = home.position;
            agent.SetDestination(newDestination);
    
        }

        if (Vector3.Distance(agent.transform.position, home.position) < 6)
        {
            print("opa cheguei em casa!!!");

            newDestination = target[contador].position;
            agent.SetDestination(newDestination);
        }

    }
}

