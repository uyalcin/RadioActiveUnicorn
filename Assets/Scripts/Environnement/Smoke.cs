using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update () {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plateform")
        {
            Destroy(gameObject);
        }
    }
}
