using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceWhenCreated : MonoBehaviour {

    public Vector2 force;

	void Start () {
        GetComponent<Rigidbody2D>().AddForce(force);
    }
}
