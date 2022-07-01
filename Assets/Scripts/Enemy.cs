using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
public Transform MyPlayer;
private NavMeshAgent _myAgent;

    void Start()
    {
        _myAgent = GetComponent <NavMeshAgent>();
        MyPlayer = GameObject.FindObjectOfType<Player>().transform;
    }
    
    void Update()
    {
        _myAgent.destination = MyPlayer.transform.position;
    }
    
    public void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}
