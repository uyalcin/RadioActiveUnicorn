using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour {

    public float interval;
    public GameObject objectToDrop;

    bool active;
    TriggerInterface trigger;

    private void Start()
    {
        active = false;
        trigger = GetComponent<TriggerInterface>();
    }

    void Update () {
		if(!active && trigger.isActive())
        {
            active = true;
            InvokeRepeating("dropObject", 0f, interval);
        }
        if(active && !trigger.isActive())
        {
            active = false;
            CancelInvoke();
        }
	}

    void dropObject()
    {
        Instantiate(objectToDrop, transform.position, Quaternion.identity);
    }
}
