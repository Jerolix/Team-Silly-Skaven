using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltStatus : MonoBehaviour
{
    public bool isHit = false;

    private void Start()
    {
        print("Bolt Shot");
    }


    void OnCollisionEnter(Collision gameObject)
    {
        if (isHit == false)
        {
            isHit = true;
            print("Hit");
        }
    }
}
