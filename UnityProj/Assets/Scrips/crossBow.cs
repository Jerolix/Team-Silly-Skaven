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
    public AudioSource audioSource;
    public AudioClip CrossbowV2Shoot;
    public AudioClip CrossbowV2Reload;
    public AudioClip CrossbowV2SafetyOff;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();

        if (canFire == false)
        {
            canFire = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canFire == true)
            {
                {
                    audioSource.PlayOneShot(CrossbowV2SafetyOff, 1.0f);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (canFire == true) 
            {   
                canFire= false;

                bowAnimator.SetTrigger("Fired");
                var Bolt = Instantiate(boltPrefab, boltSpawnPoint.position, boltSpawnPoint.rotation);//gets the bolt to appear and where it should appear, the origin point of the crossbow
                Bolt.GetComponent<Rigidbody>().velocity = boltSpawnPoint.forward * boltSpeed; //get bolt to move.

                audioSource.PlayOneShot(CrossbowV2Shoot, 1.0f);

                StartCoroutine(Cooldown());
            }
        }
    }


    IEnumerator Cooldown()
    {
        audioSource.PlayOneShot(CrossbowV2Reload, 1.0f);
        print("RETRACTING");
        bowAnimator.SetTrigger("Retracting");
        yield return new WaitForSeconds(1.25f);
        //bowAnimator.SetTrigger("Idle");
        canFire = true;
    }

}
