using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class targetStatus : MonoBehaviour
{
    public bool isHit = false;
    public TextMeshProUGUI scoreText;
    private hitCounter counterInt;
    public AudioSource woodImpact;
    public AudioSource pingEffect;

    // Start is called before the first frame update
    void Start()
    {
        counterInt = scoreText.GetComponent<hitCounter>();
    }

    void UpdateCounter()
    {
        pingEffect.Play();
        counterInt.targetsHit++;
    }

    void OnCollisionEnter(Collision Collider)
    {
        if (isHit == false && Collider.gameObject.tag == "Bolt")
        {
            isHit = true;
            UpdateCounter();
            if (woodImpact.isPlaying == false)
            {
                woodImpact.pitch = Random.Range(0.75f, 1.5f);
                woodImpact.Play();
            }
            print("Hit by Bolt");
        }
        if (isHit == false && Collider.gameObject.tag == "Prop")
        {
            isHit = true;
            UpdateCounter();
            if (woodImpact.isPlaying == false)
            {
                woodImpact.pitch = Random.Range(0.75f, 1.5f);
                woodImpact.Play();
            }
            print("Hit by Prop");
        }
        else
        {
            if (woodImpact.isPlaying == false)
            {
                woodImpact.pitch = Random.Range(0.75f, 1.5f);
                woodImpact.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
