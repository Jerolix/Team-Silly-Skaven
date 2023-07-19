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


    void OnCollisionEnter(Collision Collider)
    {
        if (isHit == false && Collider.gameObject.tag != "Prop")
        {
            isHit = true;
            OnTouched();
            print("Hit");
        }
        if (isHit == false && Collider.gameObject.tag == "Prop")
        {
            transform.parent = Collider.gameObject.transform;
            isHit = true;
            StartCoroutine(HitProp());

            print("Hit Prop");
        }
    }

    IEnumerator HitProp()
    {
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 15);

    }
    void OnTouched()
    {
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 15);
    }

}
