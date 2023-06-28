using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObject : MonoBehaviour
{
    private List<GameObject> pullObjects;
    public Vector3 pullDirection;
    public float pullSpeed;
    void Start()
    {
        pullObjects = new List<GameObject>();
    }

    void Update()
    {
        foreach (GameObject obj in pullObjects)
        {
            obj.transform.Translate(Time.deltaTime * pullSpeed * pullDirection);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("object entered");
        pullObjects.Add(col.gameObject);
    }


    public void OnTriggerExit(Collider col)
    {
        pullObjects.Remove(col.gameObject);
    }

}
