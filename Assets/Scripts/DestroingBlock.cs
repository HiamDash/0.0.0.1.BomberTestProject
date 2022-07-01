using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroingBlock : MonoBehaviour
{
        public void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Explosion")||other.CompareTag ("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}