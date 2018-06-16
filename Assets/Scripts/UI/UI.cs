using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public GameObject licorne;
	public GameObject purityBar;

	void Update () {
		purityBar.GetComponent<Image> ().fillAmount = licorne.GetComponent<CharacterController> ().purity / 100f;
	}
}
