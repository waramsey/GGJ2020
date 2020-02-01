using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour //attach to an enemy spawner
{

    public GameObject toSpawn; //GameObject to create
    public GameObject virtualCamera;

    void Update()
    {
        if (virtualCamera.activeInHierarchy)
        {
            Instantiate(toSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
