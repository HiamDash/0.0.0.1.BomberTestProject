using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
  public GameObject EnemyPrefab;

  private float _timeBetweenSpawn;
  private float _spawnTime; 

    void Start()
    {
        _spawnTime = 0;
        _timeBetweenSpawn = 5;
    }
    void Update()
    {
      _timeBetweenSpawn -=1*Time.deltaTime; 
      if(_timeBetweenSpawn <= _spawnTime)
      {
        Spawn();
        _timeBetweenSpawn += 5;
      }  
    }

    void Spawn()
    {
    Instantiate(EnemyPrefab, transform.position + new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
    }    
}
