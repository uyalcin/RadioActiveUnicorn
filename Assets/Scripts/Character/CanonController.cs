using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour {

	public bool canonLeft = true;
	public float canonPower;
	public float canonCost;

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Enemy" && Input.GetKeyDown(KeyCode.D) &&
			transform.parent.GetComponent<CharacterController> ().purity >= canonCost)
		{
			Vector2 direction = canonLeft ? Vector2.left : Vector2.right;
			col.GetComponent<Rigidbody2D> ().AddForce (direction * canonPower, ForceMode2D.Impulse);

			transform.parent.GetComponent<CharacterController> ().dropPurity (canonCost);
			col.transform.GetComponentInChildren<RadioactivityZone> ().decreaseZone (2);
		}
	}
}
