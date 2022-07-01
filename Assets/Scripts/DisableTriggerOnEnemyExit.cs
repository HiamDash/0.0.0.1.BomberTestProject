using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTriggerOnEnemyExit : MonoBehaviour
{
    public void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            GetComponent<Collider> ().isTrigger = false;
        }
    }
}