using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossBow : MonoBehaviour
{
    public Transform boltSpawnPoint;
    public GameObject boltPrefab;
    public float boltSpeed = 10;
    [SerializeField] private bool canFire;
    [SerializeField] private Animator bowAnimator;

    private void Start()
    {
        if (canFire == false)
        {
            canFire = true;
        }
    }

    void Update()
    {
       /* if (Input.GetMouseButtonDown(0))
        {
            if (canFire == true)
            {
                {
                    bowAnimator.SetTrigger("Retracting");
                }
            }
        }*/
        if (Input.GetMouseButtonUp(0))
        {
            if (canFire == true) 
            {   
                canFire= false;

                bowAnimator.SetTrigger("Fired");
                var Bolt = Instantiate(boltPrefab, boltSpawnPoint.position, boltSpawnPoint.rotation);//gets the bolt to appear and where it should appear, the origin point of the crossbow
                Bolt.GetComponent<Rigidbody>().velocity = boltSpawnPoint.forward * boltSpeed; //get bolt to move.

                StartCoroutine(Cooldown());
            }
        }
    }


    IEnumerator Cooldown()
    {
        print("RETRACTING");
        bowAnimator.SetTrigger("Retracting");
        yield return new WaitForSeconds(1.25f);
        //bowAnimator.SetTrigger("Idle");
        canFire = true;
    }

}
