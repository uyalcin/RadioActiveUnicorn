using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour {

	public float vacuumPower;
	public float purityGain;

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "RadioActivityZone" && Input.GetAxis("Vacuum") > 0) 
		{
			col.GetComponent<RadioactivityZone> ().decreaseZone (vacuumPower);
			transform.parent.GetComponent<CharacterController> ().winPurity (purityGain);
			//Debug.Log ("Aspiration");
		}
	}
}
