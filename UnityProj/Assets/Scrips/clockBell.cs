using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockBell : MonoBehaviour
{
    public AudioSource clockRing;

   

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Clock")
        {
            clockRing.Play();
        }
    }
}
