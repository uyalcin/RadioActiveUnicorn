using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour {
    public GameObject target;

    private Vector3 offset;

    TriggerNearObject trigger;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }
    
    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
