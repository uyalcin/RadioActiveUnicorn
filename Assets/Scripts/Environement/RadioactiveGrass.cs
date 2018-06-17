using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveGrass : MonoBehaviour {

    public float jumpForce;
    
    bool purified;
    bool bounce;

	void Start () {
        purified = false;
        bounce = false;
	}

	void Update () {
        if (!purified && GetComponentInChildren<RadioactivityZone>().getZoneRadius() <= 0.2f)
        {
            purified = true;
            Destroy(GetComponentInChildren<RadioactivityZone>().gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && col.transform.position.y >= transform.position.y && purified && !bounce)
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(col.GetComponent<Rigidbody2D>().velocity.x, 0f);
            col.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            bounce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && bounce)
        {
            bounce = false;
        }
    }
}
