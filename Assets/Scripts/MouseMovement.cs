using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MouseMovement : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;

    public GameObject formation;
    public GameObject pos1;



    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetDestinationToMousePosition();
        }
    }

    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            formation.transform.position = hit.point;

                myNavMeshAgent.SetDestination(pos1.transform.position);

        }
    }
}
