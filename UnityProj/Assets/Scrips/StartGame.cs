using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton;
    public AudioSource clickSound;
    public Animator fadeScreenController;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    IEnumerator coroutineA()
    {
        fadeScreenController.SetTrigger("FadeBlack");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        StartCoroutine(coroutineA());
    }
}
