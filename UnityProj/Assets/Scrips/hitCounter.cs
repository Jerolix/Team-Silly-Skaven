using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class hitCounter : MonoBehaviour
{
    public int targetsHit = 0;
    public int maxTargets;
    public TextMeshProUGUI scoreText;
    public Animator counterAnimator;
    public TextMeshProUGUI timerText;

    public float currentTime = 0;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText.text != "Targets Hit: " + targetsHit + "/" + maxTargets)
        {
            counterAnimator.SetTrigger("ValueChanged");
            scoreText.text = "Targets Hit: " + targetsHit + "/" + maxTargets;
        }
    }


    IEnumerator Timer()
    {
        while (true) 
        {
            if (targetsHit < maxTargets)
            {
                yield return new WaitForSeconds(1.0f);
                currentTime += 1.0f;
                timerText.text = "Time: " + currentTime.ToString() + "s";
            }
            else if (targetsHit >= maxTargets)
            {
                timerText.color = Color.green;
                StopCoroutine(Timer());
                break;
            }
        }
    }
}
