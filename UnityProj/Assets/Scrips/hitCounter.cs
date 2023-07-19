using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class hitCounter : MonoBehaviour
{
    public int targetsHit = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText.text != "Targets Hit: " + targetsHit)
        {
            scoreText.text = "Targets Hit: " + targetsHit;
        }
    }
}
