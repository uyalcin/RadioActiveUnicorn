using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNearObject : MonoBehaviour, TriggerInterface {
    const float nearDistance = 0.2f;

    public GameObject triggerObject;
    public Camera cam;
    public double triggerDistance;
    public bool sleepWhenOffScreen;
    public bool sleepWhenNear;
    public bool neverSleep;

    bool active;

    void Start () {
        active = false;
    }
	

	void Update () {
        float distance = Vector2.Distance(transform.position, triggerObject.transform.position);
        if (!active && (distance < triggerDistance) && ((distance > nearDistance) || !sleepWhenNear))
        {
            active = true;
        }

        if(!neverSleep && active && ((!isOnScreen() && sleepWhenOffScreen) || ((distance <= nearDistance) && sleepWhenNear)) || (!sleepWhenOffScreen && (distance > triggerDistance)))
        {
            active = false;
        }
	}

    bool isOnScreen()
    {
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position) - cam.WorldToScreenPoint(cam.transform.position);
        return (Mathf.Abs(screenPosition.x) < (Screen.width / 2)) && (Mathf.Abs(screenPosition.y) < (Screen.height / 2));
    }

    public bool isActive()
    {
        return active;
    }
}
