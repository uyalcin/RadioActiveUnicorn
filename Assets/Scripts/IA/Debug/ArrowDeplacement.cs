using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDeplacement : MonoBehaviour {
    public float speed;

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
    }
}
