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

    // Start is called before the first frame update
    void Start()
    {
        counterInt = scoreText.GetComponent<hitCounter>();
    }

    void UpdateCounter()
    {
        counterInt.targetsHit++;
    }

    void OnCollisionEnter(Collision Collider)
    {
        if (isHit == false && Collider.gameObject.tag == "Bolt")
        {
            isHit = true;
            UpdateCounter();
            print("Hit by Bolt");
        }
        if (isHit == false && Collider.gameObject.tag == "Prop")
        {
            isHit = true;
            UpdateCounter();

            print("Hit by Prop");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
