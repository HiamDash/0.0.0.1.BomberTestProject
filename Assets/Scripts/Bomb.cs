using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public LayerMask _levelMask;
    [SerializeField] private GameObject explosionPrefab;

    private bool _exploded = false;
    
    void Explode() 
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); 
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));
        GetComponent<MeshRenderer>().enabled = false; 
        _exploded = true; 
        transform.Find("Collider").gameObject.SetActive(false); 
        Destroy(gameObject, .1f);
    }
    
    private IEnumerator CreateExplosions(Vector3 direction) 
    {
        for (int i = 1; i < 3; i++) 
        { 
        RaycastHit hit; 
        Physics.Raycast(transform.position + new Vector3(0,.5f,0), direction, out hit, i, _levelMask);
        if (!hit.collider) 
        { 
        Instantiate(explosionPrefab, transform.position + (i * direction),
        explosionPrefab.transform.rotation); 
        } 
        else 
        {
        break; 
        }
        yield return new WaitForSeconds(.01f); 
        }
    }
    public void OnTriggerEnter(Collider other) 
    {
        if (!_exploded && other.CompareTag("Explosion"))
    { 
    CancelInvoke("Explode");
    Explode(); 
    }
    }

    void Update()
    {
        Invoke("Explode", 2f);
    }
}
