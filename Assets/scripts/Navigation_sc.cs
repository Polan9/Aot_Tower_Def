using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Navigation_sc : MonoBehaviour
{


    public Transform Baza;

    private NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.destination = Baza.position;

    }

    void Update()
    {
    }
}
