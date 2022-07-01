using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float Delay = 3f;
    
    void Start ()
    {
        Destroy (gameObject, Delay);
    }
}
