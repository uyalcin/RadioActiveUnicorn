using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOverObject : MonoBehaviour, TriggerInterface
{

    public GameObject triggerObject;
    public Vector2 triggerDistance;

    bool active;

    void Start()
    {
        active = false;
    }


    void Update()
    {
        Vector2 distance = new Vector2(Mathf.Abs(transform.position.x - triggerObject.transform.position.x), transform.position.y - triggerObject.transform.position.y);
        active = (distance.y < triggerDistance.y) && (distance.y > 0) && (distance.x < triggerDistance.x);
    }

    public bool isActive()
    {
        return active;
    }
}
