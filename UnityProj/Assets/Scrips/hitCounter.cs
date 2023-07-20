using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class hitCounter : MonoBehaviour
{
    public int targetsHit = 0;
    public TextMeshProUGUI scoreText;
    public Animator counterAnimator;

    // Update is called once per frame
    void Update()
    {
        if (scoreText.text != "Targets Hit: " + targetsHit + "/17")
        {
            counterAnimator.SetTrigger("ValueChanged");
            scoreText.text = "Targets Hit: " + targetsHit + "/17";
        }
    }
}
