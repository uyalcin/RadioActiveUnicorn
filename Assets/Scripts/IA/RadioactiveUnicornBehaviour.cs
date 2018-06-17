using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveUnicornBehaviour : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator anim;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	void Update () {
		if(GetComponentInChildren<RadioactivityZone>().getZoneRadius() <= 1f)
        {
			GetComponent<MoveToObject>().enabled = false;
			Destroy(transform.GetChild(0).gameObject);
        }
		if (rb.velocity.x < 0f) {
			anim.SetBool ("facingRight", false);
			anim.SetBool ("moving", true);
		} else if (rb.velocity.x > 0f) {
			anim.SetBool ("facingRight", true);
			anim.SetBool ("moving", true);
		} else {
			anim.SetBool ("moving", false);
		}
		Debug.Log (GetComponentInChildren<RadioactivityZone> ().getZoneRadius ());
		anim.SetFloat ("radioactiveLevel", GetComponentInChildren<RadioactivityZone>().getZoneRadius());
	}
}
