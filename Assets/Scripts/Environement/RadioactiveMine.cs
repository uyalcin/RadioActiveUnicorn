using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveMine : MonoBehaviour {

    public float interval;
    public GameObject objectToDrop;

    private void Start()
    {
        InvokeRepeating("dropObject", Random.Range(0f, interval), interval);
    }

    void dropObject()
    {
        Instantiate(objectToDrop, transform.position, Quaternion.identity);
    }
}
