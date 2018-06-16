using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingFromGround : MonoBehaviour {

    public float height;
    public float speed;

    float originalY;

    TriggerInterface trigger;

    private void Start()
    {
        trigger = GetComponent<TriggerInterface>();
        originalY = transform.position.y;
        moveY(originalY - height);
    }

    void FixedUpdate()
    {
        if(trigger.isActive() && (transform.position.y < originalY))
        {
            moveY(transform.position.y + speed);
        }
        if(!trigger.isActive() && (transform.position.y > (originalY - height)))
        {
            moveY(transform.position.y - speed);
        }
    }

    void moveY(float y)
    {
        transform.position = new Vector2(transform.position.x, y);
    }

    public float getState()
    {
        return (transform.position.y - originalY + height) / height;
    }
}
