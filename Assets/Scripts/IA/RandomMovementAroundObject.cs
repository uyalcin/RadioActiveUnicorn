using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementAroundObject : MonoBehaviour {

    public GameObject target;
    public float movementRange;
    public float minSpeed;
    public float maxSpeed;

    float direction;
    float speed;
    float initMovementRange;

    Rigidbody2D rb;

    void Start () {
		if(isOnTheRight())
        {
            direction = -1f;
        } else if(isOnTheLeft())
        {
            direction = 1f;
        } else
        {
            direction = (Random.Range(0, 2) == 0) ? 1 : -1;
        }
        speed = Random.Range(minSpeed, maxSpeed);

        rb = GetComponent<Rigidbody2D>();
        initMovementRange = movementRange;
    }
	

	void Update () {
        if(direction < 0f && isOnTheLeft())
        {
            direction = 1f;
        }
        if(direction > 0f && isOnTheRight())
        {
            direction = -1f;
        }

        if(rb.velocity.y == 0f)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        }
    }

    bool isOnTheRight()
    {
        return transform.position.x > target.transform.position.x + movementRange;
    }

    bool isOnTheLeft()
    {
        return transform.position.x < target.transform.position.x - movementRange;
    }

    public void setMovementRangeCoef(float coef)
    {
        movementRange = initMovementRange * coef;
    }
}
