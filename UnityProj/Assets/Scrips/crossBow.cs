using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossBow : MonoBehaviour
{
    public Transform boltSpawnPoint;
    public GameObject boltPrefab;
    public float boltSpeed = 10;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var Bolt = Instantiate(boltPrefab, boltSpawnPoint.position, boltSpawnPoint.rotation);//gets the bolt to appear and where it should appear, the origin point of the crossbow
            Bolt.GetComponent<Rigidbody>().velocity = boltSpawnPoint.forward * boltSpeed;//get bolt to move.
        }
    }
}
