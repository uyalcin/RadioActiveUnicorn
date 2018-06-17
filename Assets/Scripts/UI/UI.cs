using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public CharacterController licorne;
	public GameObject purityBar;
	public Image jump;
	public Image canon;
	public Image treat;


	void Update () {
		purityBar.GetComponent<Image> ().fillAmount = licorne.purity / 100f;

		if (licorne.purity >= licorne.maxJumpCost) {
			jump.color = Color.green;
		}
		else {
			jump.color = Color.white;
		}

		if (licorne.purity >= licorne.canonCost) {
			canon.color = Color.green;
		}
		else {
			canon.color = Color.white;
		}

		if (licorne.purity > 0) {
			treat.color = Color.green;
		}
		else {
			treat.color = Color.white;
		}
	}
}
